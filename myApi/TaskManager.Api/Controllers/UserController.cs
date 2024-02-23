//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using TaskManager.Core.Helpers;
//using TaskManager.Core.RepositoriesAbstractions;
//using TaskManager.DataAccess.Entities;
//using TaskManagerApi.Dtos;

//namespace TaskManagerApi.Controllers
//{
//    [Route("api")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IUserRepository _repository;
//        private readonly JwtService _jwtService;

//        public AuthController(IUserRepository repository, JwtService jwtService)
//        {
//            _repository = repository;
//            _jwtService = jwtService;
//        }

//        [HttpPost("register")]

//        public IActionResult Register([FromBody]RegisterDto dto)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest();
//            }


//            UserEntity userEntity = new UserEntity
//            {
//                Login = dto.Login,
//                Pass = dto.Pass,
//            };

//            return Created("success", _repository.Create(userEntity));    
//        }

//        [HttpPost("login")]
//        public IActionResult Login(LoginDto dto)
//        {
//            var user = _repository.GetByLogin(dto.Login);

//            if (user == null) return BadRequest(new { message = "Неверный логин или пароль" });

//            if (!(dto.Pass == user.Pass))
//            {
//                return BadRequest(new { message = "Неверный логин или пароль" });
//            }

//            var jwt = _jwtService.Generate(user.Id);

//            Response.Cookies.Append("jwt", jwt, new CookieOptions
//            {
//                HttpOnly = true,
//                SameSite = SameSiteMode.None,
//                Secure = true,
//            });

//            return Ok(new
//            {
//                message = "success"
//            });
//        }
//        [HttpGet("userEntity")]
//        public IActionResult User()
//        {
//            try
//            {
//                var jwt = Request.Cookies["jwt"];

//                var token = _jwtService.Verify(jwt);

//                int userId = int.Parse(token.Issuer);

//                var user = _repository.GetById(userId);

//                return Ok(user);
//            }
//            catch (Exception)
//            {
//                return Unauthorized();
//            }
//        }

//        [HttpPost("logout")]
//        public IActionResult Logout()
//        {
//            Response.Cookies.Delete("jwt", new CookieOptions
//            {
//                HttpOnly = true,
//                Secure = true,  
//                SameSite = SameSiteMode.None 
//            });


//            return Ok(new
//            {
//                message = "success"
//            });
//        }

//        private Dictionary<string, List<string>> ModelStateToDictionary(ModelStateDictionary modelState)
//        {
//            return modelState.ToDictionary(
//                kvp => kvp.Key,
//                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
//            );
//        }
//    }

//}
