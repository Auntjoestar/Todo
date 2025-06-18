using Todo.DTOs.Activity;
using Todo.Models;

namespace Todo.Mappers
{
    public static class ActivityMappers
    {
        public static ActivityDto ToActivityDto(this Activity activity)
        {
            string status = activity.Status switch
            {
                Status.Active => "Active",
                Status.Inactive => "Inactive",
                Status.OnHold => "On Hold",
                _ => throw new Exception("Status not valid."),
            };

            return new ActivityDto
            {
                ID = activity.ID,
                Name = activity.Name,
                Description = activity.Description,
                Status = status,
                UserId = activity.UserId,
            };
        }

        public static Activity ToActivityFromCreateActivityDto(this CreateActivityDto createActivityDto)
        {
            var status = createActivityDto.Status switch
            {
                "Active" => Status.Active,
                "Inactive" => Status.Inactive,
                "On Hold" => Status.OnHold,
                _ => throw new Exception("Status not valid."),
            };

            return new Activity
            {
                Name = createActivityDto.Name,
                Description = createActivityDto.Description,
                Status = status,
                UserId = "",
            };
        }

        public static Activity ToActivityFromUpdateActivityDto(this UpdateActivityDto updateActivityDto)
        {
            var status = updateActivityDto.Status switch
            {
                "Active" => Status.Active,
                "Inactive" => Status.Inactive,
                "On Hold" => Status.OnHold,
                _ => throw new Exception("Status not valid."),
            };

            return new Activity
            {
                Name = updateActivityDto.Name,
                Description = updateActivityDto.Description,
                Status = status,
                UserId = "",
            };
        }
    }
}