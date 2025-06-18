using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.DTOs.Activity;
using Todo.Interfaces;
using Todo.Mappers;

namespace Todo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/activity")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
            {
                return Forbid();
            }

            var activities = await _activityRepository.GetAllAsync(userId);
            var activityDtos = activities.Select(activity => activity.ToActivityDto());

            return Ok(activityDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
            {
                return Forbid();
            }

            var activity = await _activityRepository.GetByIdAsync(userId, id);
            if (activity is null)
            {
                return NotFound();
            }
            return Ok(activity.ToActivityDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateActivityDto createActivityDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
            {
                return Forbid();
            }

            var newActivity = await _activityRepository.CreateAsync(userId, createActivityDto);

            return CreatedAtAction(nameof(GetById), new { id = newActivity.ID }, newActivity.ToActivityDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateActivityDto updateActivityDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
            {
                return Forbid();
            }

            var updatedActivity = await _activityRepository.UpdateAsync(id, userId, updateActivityDto);
            if (updatedActivity is null)
            {
                return NotFound();
            }

            return Ok(updatedActivity.ToActivityDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
            {
                return Forbid();
            }

            var deletedUser = await _activityRepository.DeleteAsync(userId, id);
            if (deletedUser is null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}