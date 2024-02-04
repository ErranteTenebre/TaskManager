using System.ComponentModel.DataAnnotations;

namespace SimpleTODOLesson.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Pass { get; set; }
        public string Login { get; set; }
    }
}
