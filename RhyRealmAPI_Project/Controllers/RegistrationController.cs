using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RhyRealmAPI_Project.Models;
using RhyRealmAPI_Project.Service;

namespace RhyRealmAPI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RhyRealm_Context _context;
        private readonly EmailService _emailService;


        public RegistrationController(RhyRealm_Context context, EmailService emailService)
        {
            _context = context;
            _emailService= emailService;
        }

        //POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> SendToEmail(string EmailUser)
        {
            Random random = new Random();
            var code = random.Next(100000,999999);

            string subject = "Код подтверждения";
            string body = "<h1>Код подтверждения регистрации в RhyRealm!</h1>\r\n\r\n<h3>Если вы не запрашивали код, просто проигнорируйте это письмо</h3>\r\n\r\n<div>Ваш код подтверждения:" + code + " </div>\r\n\r\n\n\n\n\n<h4>RhyRealm</h4>";


            await _emailService.SendEmailAsync(EmailUser, subject, body);


            return Ok("Письмо отправлено!");
        }
    }
}
