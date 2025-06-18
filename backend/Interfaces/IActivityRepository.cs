using Todo.DTOs.Activity;
using Todo.Models;

namespace Todo.Interfaces
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAllAsync(string userId);
        Task<Activity?> GetByIdAsync(string userId, int id);
        Task<Activity> CreateAsync(string userId, CreateActivityDto createActivityDto);
        Task<Activity?> UpdateAsync(int id, string userId, UpdateActivityDto updateActivityDto);
        Task<Activity?> DeleteAsync(string userId, int id);
    }
}