using System.Security.Claims;
using Ascendix_Backend.Models;
using LinternBackend.Token;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("/")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService; // Adjust name to your service

        public AuthController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Starts Google OAuth flow by redirecting the request to Google.
        /// </summary>
        [HttpGet("auth/login/google")]
        public IActionResult GoogleLogin(string? returnUrl)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(GoogleCallback), new { returnUrl })
            };

            // Challenge triggers the external provider redirect
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// Google callback endpoint. Returns JSON with token + user info.
        /// This must match the CallbackPath registered in GoogleOptions ("/signin-google").
        /// </summary>
        [HttpGet("signin-google")]
        public async Task<IActionResult> GoogleCallback(string? returnUrl)
        {
            // Try to get the external login info from SignInManager
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                // Sometimes GetExternalLoginInfoAsync can fail; try to read the external identity directly
                var extAuth = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);
                if (!extAuth.Succeeded || extAuth.Principal == null)
                {
                    return BadRequest(new { error = "External authentication failed." });
                }

                // Build ExternalLoginInfo from principal (fallback)
                var providerKey = extAuth.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var provider = extAuth.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Issuer ?? GoogleDefaults.AuthenticationScheme;

                if (providerKey == null)
                    return BadRequest(new { error = "External provider did not return an id." });

                info = new ExternalLoginInfo(extAuth.Principal, GoogleDefaults.AuthenticationScheme, providerKey, GoogleDefaults.AuthenticationScheme);
            }

            // Extract email and name (prefer standard claim types)
            var email = info.Principal.FindFirstValue(ClaimTypes.Email)
                      ?? info.Principal.FindFirstValue("email")
                      ?? info.Principal.FindFirstValue(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email);

            var displayName = info.Principal.FindFirstValue(ClaimTypes.Name)
                              ?? info.Principal.FindFirstValue("name");

            if (string.IsNullOrEmpty(email))
                return BadRequest(new { error = "Email not returned by external provider." });

            // Try sign-in by external login (if already linked)
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            User user = null;

            if (signInResult.Succeeded)
            {
                // External login exists - load the user
                user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            }
            else
            {
                // Not linked yet - locate user by email
                user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    // Auto-create the user (you requested auto-create)
                    user = new User
                    {
                        UserName = email,
                        Email = email,
                        EmailConfirmed = true // Google validated email
                        // If you have other fields (FirstName, LastName) set them here using claims
                    };

                    var createResult = await _userManager.CreateAsync(user);
                    if (!createResult.Succeeded)
                    {
                        // Clean up the external cookie and return errors
                        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
                        return StatusCode(500, new { error = "Failed to create local user.", details = createResult.Errors.Select(e => e.Description) });
                    }
                }

                // Link the external login to this user
                var addLoginResult = await _userManager.AddLoginAsync(user, info);
                if (!addLoginResult.Succeeded)
                {
                    // If linking failed, you may still proceed or return an error depending on your policy.
                    // Here we continue but log the issue (or return an error as you prefer).
                    await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
                    return StatusCode(500, new { error = "Failed to link external login.", details = addLoginResult.Errors.Select(e => e.Description) });
                }

                // Optionally sign-in the user with Identity cookie (not necessary for JWT flow)
                // await _signInManager.SignInAsync(user, isPersistent: false);
            }

            // Get roles to pass to your CreateToken method
            var roles = await _userManager.GetRolesAsync(user);
            var roleList = roles?.ToList() ?? new List<string>();

            // Create token using your existing method
            // Ensure your ITokenService exposes: string CreateToken(User user, IList<string> userRoles)
            var token = _tokenService.CreateToken(user, roleList);

            // Remove the external cookie
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            // Return the token + basic user info as JSON (as requested)
            return Ok(new
            {
                token,
                user = new
                {
                    id = user.Id,
                    email = user.Email
                }
            });
        }
    }
}
