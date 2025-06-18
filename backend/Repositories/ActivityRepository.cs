using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Todo.Data;
using Todo.DTOs.Activity;
using Todo.Interfaces;
using Todo.Mappers;
using Todo.Models;

namespace Todo.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDBContext _context;

        public ActivityRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Activity> CreateAsync(string userId, CreateActivityDto createActivityDto)
        {
            var activity = createActivityDto.ToActivityFromCreateActivityDto();
            activity.UserId = userId;

            await _context.Activity.AddAsync(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task<Activity?> DeleteAsync(string userId, int id)
        {
            var activity = await _context.Activity
            .FirstOrDefaultAsync(activity => activity.ID == id && activity.UserId == userId);
            if (activity is null)
            {
                return null;
            }

            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task<List<Activity>> GetAllAsync(string userId)
        {
            return await _context.Activity
            .Where(activity => activity.UserId == userId)
            .OrderBy(activity => activity.ID)
            .ToListAsync();
        }

        public async Task<Activity?> GetByIdAsync(string userId, int id)
        {
            var activity = await _context.Activity
            .FirstOrDefaultAsync(activity => activity.ID == id && activity.UserId == userId);

            if (activity is null)
            {
                return null;
            }

            return activity;
        }

        public async Task<Activity?> UpdateAsync(int id, string userId, UpdateActivityDto updateActivityDto)
        {
            var activity = await _context.Activity.FirstOrDefaultAsync(activity => activity.ID == id && activity.UserId == userId);
            if (activity is null)
            {
                return null;
            }

            var activityDtoToActivity = updateActivityDto.ToActivityFromUpdateActivityDto();
            activityDtoToActivity.UserId = userId;

            activity.Name = activityDtoToActivity.Name;
            activity.Description = activityDtoToActivity.Description;
            activity.Status = activityDtoToActivity.Status;
            activity.UserId = activityDtoToActivity.UserId;

            await _context.SaveChangesAsync();

            return activity;
        }
    }
}