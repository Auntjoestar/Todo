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

        public async Task<Activity> CreateAsync(CreateActivityDto createActivityDto)
        {
            var activity = createActivityDto.ToActivityFromCreateActivityDto();
            await _context.Activity.AddAsync(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task<Activity?> DeleteAsync(int id)
        {
            var activity = await _context.Activity.FindAsync(id);
            if (activity is null)
            {
                return null;
            }

            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task<List<Activity>> GetAllAsync()
        {
            return await _context.Activity.OrderBy(activity => activity.ID).ToListAsync();
        }

        public async Task<Activity?> GetByIdAsync(int id)
        {
            var activity = await _context.Activity.FindAsync(id);
            if (activity is null)
            {
                return null;
            }

            return activity;
        }

        public async Task<Activity?> UpdateAsync(int id, UpdateActivityDto updateActivityDto)
        {
            var activity = await _context.Activity.FindAsync(id);
            if (activity is null)
            {
                return null;
            }

            var activityDtoToActivity = updateActivityDto.ToActivityFromUpdateActivityDto();

            activity.Name = activityDtoToActivity.Name;
            activity.Description = activityDtoToActivity.Description;
            activity.Status = activityDtoToActivity.Status;

            return activity;
        }
    }
}