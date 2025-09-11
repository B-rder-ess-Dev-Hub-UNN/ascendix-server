using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.UserDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using LinternBackend.Token;
using Microsoft.AspNetCore.Identity;

namespace Ascendix_Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        public UserRepository(
            AppDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenService tokenService
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<User?> addWalletAddress(string userId, string walletAddress)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return null;

            user.walletAddress = walletAddress;
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<(User? User, string? ErrorMessage)> createAdmin(string email, string password)
        {
            try
            {
                var currentAdmin = new User
                {
                    Email = email,
                    UserName = email
                };
                var createuser = await _userManager.CreateAsync(currentAdmin, password);
                if (createuser.Succeeded)
                {
                    var RoleResult = await _userManager.AddToRoleAsync(currentAdmin, "Admin");
                    var userRole = await _userManager.GetRolesAsync(currentAdmin);

                    if (RoleResult.Succeeded)
                    {
                        return (currentAdmin, null);
                    }
                    else
                    {
                        var errors = string.Join("; ", RoleResult.Errors.Select(e => e.Description));
                        return (null, $"Admin created but role assignment failed: {errors}");
                    }
                }
                else
                {
                    var errors = string.Join("; ", createuser.Errors.Select(e => e.Description));
                    return (null, $"Admin creation failed: {errors}");
                }
            }
            catch (Exception ex)
            {
                return (null, $"Unexpected error: {ex.Message}");

            }
        }

        public async Task<(User? User, string? ErrorMessage)> createUser(string email, string password)
        {
            try
            {
                var currentUser = new User
                {
                    Email = email,
                    UserName = email
                };
                var createuser = await _userManager.CreateAsync(currentUser, password);
                if (createuser.Succeeded)
                {
                    var RoleResult = await _userManager.AddToRoleAsync(currentUser, "User");
                    var userRole = await _userManager.GetRolesAsync(currentUser);

                    if (RoleResult.Succeeded)
                    {
                        return (currentUser, null);
                    }
                    else
                    {
                        var errors = string.Join("; ", RoleResult.Errors.Select(e => e.Description));
                        return (null, $"user created but role assignment failed: {errors}");
                    }
                }
                else
                {
                    var errors = string.Join("; ", createuser.Errors.Select(e => e.Description));
                    return (null, $"User creation failed: {errors}");
                }
            }
            catch (Exception ex)
            {
                return (null, $"Unexpected error: {ex.Message}");

            }
        }

        public async Task<(User? User, string? ErrorMessage)> loginUser(string email, string password)
        {
            try
            {
                var currentUser = await _userManager.FindByEmailAsync(email);
                if (currentUser == null) return (null, "Invalid Username or Password");

                var result = await _signInManager.CheckPasswordSignInAsync(currentUser, password, false);
                if (!result.Succeeded) return (null, "Invalid Username or Password");

                var userRole = await _userManager.GetRolesAsync(currentUser);
                return (currentUser, "Login Succesful");

            }
            catch (Exception ex)
            {
                return (null, $"Unexpected error: {ex.Message}");
            }
        }

        public async Task<string?> token(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return null;
            var userRole = await _userManager.GetRolesAsync(user);
            var token = _tokenService.CreateToken(user, userRole);

            return token;
        }
    }
}