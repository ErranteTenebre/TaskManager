using System.ComponentModel.DataAnnotations;

namespace MyApi.Models.Entities
{
    public class TaskEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }

        public int UserId { get; set; }
        public UserEntity UserEntity { get; set; }

        public int StatusId { get; set; }
        public TaskStatusEntity StatusEntity { get; set; }
    }
}
