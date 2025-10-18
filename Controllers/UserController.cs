using GoldCard.Data;
using GoldCard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldCard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(AppDbContext db) : ControllerBase
    {
        // GET: api
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await db.Users.AsNoTracking().ToListAsync();

        }

        // GET: api/users
        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await db.Users.FindAsync(id);
            return user is null ? NotFound() : user;
        }



        // POST: api/users
        /// <summary>
        /// Create New User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            user.Id = 0;

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/users
        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            user.Id = id;  

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await db.Users.AnyAsync(u => u.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/users
        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await db.Users.FindAsync(id);
            if (user is null) return NotFound();

            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
