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
    [Route("api/wallet")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly WalletDbContext _context;

        public WalletController(WalletDbContext context)
        {
            _context = context;
        }

        // GET: api/Wallet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wallet>>> GetWallet()
        {
          if (_context.Wallet == null)
          {
              return NotFound();
          }
            return await _context.Wallet.ToListAsync();
        }

        // GET: api/Wallet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wallet>> GetWallet(int id)
        {
          if (_context.Wallet == null)
          {
              return NotFound();
          }
            var wallet = await _context.Wallet.FindAsync(id);

            if (wallet == null)
            {
                return NotFound();
            }

            return wallet;
        }

        [HttpGet("user/{id_user}")]
        public async Task<ActionResult<IEnumerable<Wallet>>> GetWalletsByUserId(int id_user)
        {
            var wallets = await _context.Wallet.Where(w => w.id_user == id_user).ToListAsync();

            if (wallets == null || wallets.Count == 0)
            {
                return NotFound();
            }

            return wallets;
        }

         [HttpGet("user/{id_user}/{id_key_coin}")]
        public async Task<ActionResult<IEnumerable<Wallet>>> GetWalletsByUserIdByKeyCoin(int id_user, string id_key_coin)
        {
            var wallets = await _context.Wallet.Where(w => w.id_user == id_user && w.id_key_coin == id_key_coin).ToListAsync();

            if (wallets == null || wallets.Count == 0)
            {
                return NotFound();
            }

            return wallets;
        }
        // PUT: api/Wallet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWallet(int id, Wallet wallet)
        {
            if (id != wallet.Id)
            {
                return BadRequest();
            }

            _context.Entry(wallet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalletExists(id))
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

        // POST: api/Wallet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wallet>> PostWallet(Wallet wallet)
        {
          if (_context.Wallet == null)
          {
              return Problem("Entity set 'WalletDbContext.Wallet'  is null.");
          }
            _context.Wallet.Add(wallet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWallet", new { id = wallet.Id }, wallet);
        }

        // DELETE: api/Wallet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWallet(int id)
        {
            if (_context.Wallet == null)
            {
                return NotFound();
            }
            var wallet = await _context.Wallet.FindAsync(id);
            if (wallet == null)
            {
                return NotFound();
            }

            _context.Wallet.Remove(wallet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WalletExists(int id)
        {
            return (_context.Wallet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
