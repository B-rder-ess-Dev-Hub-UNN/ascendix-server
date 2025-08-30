using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.QuestDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/quest")]
    public class QuestContrloller : ControllerBase
    {
        private readonly IQuestRepository _questRepo;
        public QuestContrloller(IQuestRepository questRepo)
        {
            _questRepo = questRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> createQuest([FromBody] CreateQuest create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var quest = create.toQuest();
            await _questRepo.createQuestAsync(quest);
            return Ok(quest.fromQuest());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getall()
        {
            var quest = await _questRepo.GetAllQuestsAsync();
            var quests = quest.Select(c => c.fromQuest()).ToList();
            return Ok(quests);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var quest = await _questRepo.GetQuestByIdAsync(id);
            if (quest == null) return NotFound();

            return Ok(quest.fromQuest());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> updateQuest([FromRoute] Guid id, [FromBody] UpdateQuest update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var quest = await _questRepo.updateQuestAsync(id, update);
            if (quest == null) return NotFound();

            return Ok(quest.fromQuest());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> deleteQuest([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var quest = await _questRepo.deleteQuestByIdAsync(id);
            if (quest == null) return NotFound();
            
            return Ok();
        }
    }
}