using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RhyRealmAPI_Project.Models;
using RhyRealmAPI_Project.Security;
using RhyRealmAPI_Project.Service;

namespace RhyRealmAPI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RhyRealm_Context _context;
        private readonly EmailService _emailService;
        private readonly CacheService _cacheService;

        public RegistrationController(RhyRealm_Context context, EmailService emailService, CacheService cacheService)
        {
            _context = context;
            _emailService = emailService;
            _cacheService = cacheService;
        }

        //POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> SendToEmail(string EmailUser)
        {
            try
            {
                var user = await _context.Users.Where(n => n.EmailUser == EmailUser).FirstOrDefaultAsync();

                if (user != null)
                {
                    var role = await _context.Users.Where(n => n.RoleId == 1 || n.RoleId == 3).ToListAsync();

                    if (role == null)
                    {
                        return BadRequest("Пользователь с данной электронной почтой уже зарегистрирован!");
                    }
                }

                Random random = new Random();
                var code = random.Next(100000, 999999);

                string subject = "Код подтверждения";
                string body = "<h1>Код подтверждения регистрации в RhyRealm!</h1>\r\n\r\n<h3>Если вы не запрашивали код, просто проигнорируйте это письмо</h3>\r\n\r\n<div>Ваш код подтверждения:" + code + " </div>\r\n\r\n\n\n\n\n<h4>RhyRealm</h4>";


                await _emailService.SendEmailAsync(EmailUser, subject, body);

                _cacheService.SaveVerificationCodeToCache(EmailUser, code);


                return Ok("Письмо отправлено!");



            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPost("CheckCode")]
        public async Task<ActionResult<User>> CheckVerificationCode(string email, string? code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    return BadRequest("Ошибка кода подтверждения");
                }

                var savedCode = _cacheService.GetCode(email);

                if (string.IsNullOrEmpty(savedCode))
                {
                    return BadRequest("Ошибка кода подтверждения");
                }

                if (savedCode != code)
                {
                    return BadRequest("Ошибка кода подтверждения");

                }
                return Ok("Почта подтверждена!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPost("EnterPassword")]
        public async Task<ActionResult<User>> RegistrationUser(string email, string password, string repeatPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                {
                    return BadRequest("Введите пароль!");
                }

                if (string.IsNullOrEmpty(repeatPassword))
                {
                    return BadRequest("Повторите пароль!");
                }

                if (password != repeatPassword)
                {
                    return BadRequest("Ошибка пароля!");
                }

                User user = new User();
                user.EmailUser = email;

                var (hash, salt) = HashService.HashPassword(password);
                user.PasswordUser = hash;

                user.SaltUser = salt;

                user.RoleId = 2;

                _context.Users.Add(user);

                _cacheService.RemoveCode(email);

                await _context.SaveChangesAsync();

                return Created();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            

        }
    }
}
