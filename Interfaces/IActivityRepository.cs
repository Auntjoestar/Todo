using Todo.DTOs.Activity;
using Todo.Models;

namespace Todo.Interfaces
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAllAsync();
        Task<Activity?> GetByIdAsync(int id);
        Task<Activity> CreateAsync(CreateActivityDto createActivityDto);
        Task<Activity?> UpdateAsync(int id, UpdateActivityDto updateActivityDto);
        Task<Activity?> DeleteAsync(int id);
    }
}