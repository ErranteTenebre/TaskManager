using System.ComponentModel.DataAnnotations;

namespace MyApi.Models.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Pass { get; set; }
        public string Login { get; set; }
    }
}
