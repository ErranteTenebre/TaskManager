using System.Text.RegularExpressions;

namespace TaskManager.Core.Models;

public class User
{
    private const int MIN_LOGIN_LENGTH = 4;
    private const int MAX_LOGIN_LENGTH = 20;
    private const int MIN_PASSWORD_LENGTH = 8;

    public int? Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    private User(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public static (User user, string error) Create(string login, string password)
    {
        var error = ValidateLogin(login);
        if (!string.IsNullOrEmpty(error)) return (null, error);

        error = ValidatePassword(password);
        if (!string.IsNullOrEmpty(error)) return (null, error);

        var user = new User(login, password);

        return (user, null);
    }

    private static string ValidateLogin(string login)
    {
        if (string.IsNullOrEmpty(login)) return "Логин не может быть пустым";

        if (login.Length < MIN_LOGIN_LENGTH || login.Length > MAX_LOGIN_LENGTH)
            return $"Длина логина должна быть от {MIN_LOGIN_LENGTH} до {MAX_LOGIN_LENGTH} символов";

        if (!Regex.IsMatch(login, @"^[a-zA-Z0-9_]+$"))
            return "Логин может содержать только буквы (верхнего и нижнего регистра), цифры и символ подчеркивания";

        return null; 
    }

    private static string ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password)) return "Пароль не может быть пустым";

        if (password.Length < MIN_PASSWORD_LENGTH)
            return $"Пароль должен содержать не менее {MIN_PASSWORD_LENGTH} символов";

        return null; 
    }
}