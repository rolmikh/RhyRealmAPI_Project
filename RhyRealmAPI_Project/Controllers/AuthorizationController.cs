using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RhyRealmAPI_Project.Models;
using RhyRealmAPI_Project.Security;

namespace RhyRealmAPI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly RhyRealm_Context _context;

        public AuthorizationController(RhyRealm_Context context)
        {
            _context = context;
        }

        [HttpPost("Auth")]
        public async Task<ActionResult<User>> Authorization(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest("Введите электронную почту");
                }

                if (string.IsNullOrEmpty(password))
                {
                    return BadRequest("Введите пароль!");
                }

                var user = await _context.Users.Where(n => n.EmailUser == email).ToListAsync();

                if (user.Count == 0)
                {
                    return BadRequest("Пользователь с такой почтой не найден!");
                }

                foreach (var users in user)
                {
                    if (HashService.VerifyPassword(password, users.PasswordUser, users.SaltUser))
                    {
                        return Ok("Пользователь авторизован");
                    }

                }

                return BadRequest("Ошибка авторизации");

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            


        }

    }
}
