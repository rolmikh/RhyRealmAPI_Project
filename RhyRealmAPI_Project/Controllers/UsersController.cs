using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RhyRealmAPI_Project.DTO;
using RhyRealmAPI_Project.Models;

namespace RhyRealmAPI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RhyRealm_Context _context;

        public UsersController(RhyRealm_Context context)
        {
            _context = context;
        }


        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Select(u => new UserDTO
                {
                    IdUser = u.IdUser,
                    SurnameUser = u.SurnameUser,
                    NameUser = u.NameUser,
                    PatronymicNameUser = u.PatronymicNameUser,
                    DateBirthUser = u.DateBirthUser,
                    EmailUser = u.EmailUser,
                    BonusUser = u.BonusUser,
                    RoleId = u.RoleId,
                    PhotoUser = u.PhotoUser

                }).ToListAsync();

            return user;
        }

        // GET: api/Users/5
        // for clients
        [HttpGet("Client/{id}")]
        public async Task<ActionResult<UserPersonalPageClientDTO>> GetClient(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.Where(n => n.NameRole == "USER").FirstAsync();

            if (role == null)
            {
                return NotFound();
            }

            var userResult = new UserPersonalPageClientDTO
            {
                IdUser = user.IdUser,
                SurnameUser = user.SurnameUser,
                NameUser = user.NameUser,
                PatronymicNameUser = user.PatronymicNameUser,
                DateBirthUser = user.DateBirthUser,
                EmailUser = user.EmailUser,
                BonusUser = user.BonusUser,
                PhotoUser = user.PhotoUser
            };


            return userResult;
        }

        // GET: api/Users/5
        // for other user
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPersonalPageDTO>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            //var role = await _context.Roles.Where(n => n.NameRole != "USER").FirstAsync();

            //if (role.IdRole != user.RoleId)
            //{
            //    return NotFound();
            //}

            var userResult = new UserPersonalPageDTO
            {
                IdUser = user.IdUser,
                SurnameUser = user.SurnameUser,
                NameUser = user.NameUser,
                PatronymicNameUser = user.PatronymicNameUser,
                DateBirthUser = user.DateBirthUser,
                EmailUser = user.EmailUser,
                RoleId = user.RoleId,
                PhotoUser = user.PhotoUser
            };


            return userResult;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserUpdatePersonalPageDTO userDto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (id != user.IdUser)
            {
                return BadRequest();
            }
            user.SurnameUser = userDto.SurnameUser;
            user.NameUser = userDto.NameUser;
            user.PatronymicNameUser = userDto.PatronymicNameUser;
            user.DateBirthUser = userDto.DateBirthUser;

            //сделай подтверждение почты при ее изменении

            user.EmailUser = userDto.EmailUser;

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.IdUser }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.IdUser == id);
        }
    }
}
