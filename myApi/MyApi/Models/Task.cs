using System.ComponentModel.DataAnnotations;

namespace SimpleTODOLesson.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int StatusId { get;set; }
        public TaskStatus Status { get; set; }  
    }
}
