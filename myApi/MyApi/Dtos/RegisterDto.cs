using System.ComponentModel.DataAnnotations;

namespace SimpleTODOLesson.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Поле 'Логин' обязательное для заполнения.")]
        [MaxLength(30, ErrorMessage = "Логин не должен превышать 30 символов")]
        public string Login { set; get; }
        [Required(ErrorMessage = "Поле 'Pass' обязательное для заполнения.")]
        [MinLength(8, ErrorMessage = "Пароль должен содержать не менее 8 символов.")]
        public string Pass { set; get; }
        [Compare("Pass", ErrorMessage = "Пароли не совпадают")]
        public string RePass { set; get; }
    }
}