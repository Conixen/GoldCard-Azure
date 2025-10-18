using GoldCard.Data;
using GoldCard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldCard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController(AppDbContext db) : ControllerBase
    {
        // GET: api/cards
        /// <summary>
        /// Get all Cards
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetAll() =>
            await db.Cards.AsNoTracking().ToListAsync();

        // GET: api/cards
        /// <summary>
        /// Get Card by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Card>> GetById(int id)
        {
            var card = await db.Cards.FindAsync(id);
            return card is null ? NotFound() : card;
        }

        /// <summary>
        /// Get A random Card with UserId
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet("randomcard/{customernumber}")]
        public async Task<ActionResult<Card>> GetACardWithRightCustomerId(string customernumber)
        {
            var validUserNumber = await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.CustomerNumber == customernumber);
            if (validUserNumber == null)
            {
                return NotFound("Fel CustomerNumber");
            }

            var allCards = await db.Cards.CountAsync();
            var random = new Random();
            var givenRandomCard = random.Next(0, allCards);

            var randomCard = await db.Cards
                .Skip(givenRandomCard)
                .FirstOrDefaultAsync();

            if (randomCard == null)
            {
                return NotFound("Inga kort tillgängliga");
            }
            return Ok(randomCard);
        }

        // POST: api/cards
        /// <summary>
        /// Create a Card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Card>> Create(Card card)
        {
            card.Id = 0;  // create new id in db

            db.Cards.Add(card);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = card.Id }, card);
        }


        // PUT: api/cards
        /// <summary>
        /// Update a Card
        /// </summary>
        /// <param name="id"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Card card)
        {
            card.Id = id;  

            db.Entry(card).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await db.Cards.AnyAsync(c => c.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/cards
        /// <summary>
        /// Delete a Card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var card = await db.Cards.FindAsync(id);
            if (card is null) return NotFound();

            db.Cards.Remove(card);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
