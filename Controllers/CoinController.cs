using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using big_wallet.Infrastructure;
using big_wallet.Models;

namespace big_wallet.Controllers
{
    [Route("api/coin")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private readonly WalletDbContext _context;

        public CoinController(WalletDbContext context)
        {
            _context = context;
        }

        // GET: api/Coin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coin>>> GetCoin()
        {
          if (_context.Coin == null)
          {
              return NotFound();
          }
            return await _context.Coin.ToListAsync();
        }

        // GET: api/Coin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coin>> GetCoin(int id)
        {
          if (_context.Coin == null)
          {
              return NotFound();
          }
            var coin = await _context.Coin.FindAsync(id);

            if (coin == null)
            {
                return NotFound();
            }

            return coin;
        }

        // PUT: api/Coin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoin(int id, Coin coin)
        {
            if (id != coin.Id)
            {
                return BadRequest();
            }

            _context.Entry(coin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoinExists(id))
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

        // POST: api/Coin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Coin>>> PostCoins(List<Coin> coins)
        {
            if (coins == null || !coins.Any())
            {
                return BadRequest("No coins provided.");
            }

            _context.Coin.AddRange(coins);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoin", coins);
        }


        // DELETE: api/Coin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoin(int id)
        {
            if (_context.Coin == null)
            {
                return NotFound();
            }
            var coin = await _context.Coin.FindAsync(id);
            if (coin == null)
            {
                return NotFound();
            }

            _context.Coin.Remove(coin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoinExists(int id)
        {
            return (_context.Coin?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
