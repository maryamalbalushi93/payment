using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apymentapi.Models;

namespace apymentapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailSController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymentDetailSController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetailS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetailS>>> GetPaymentDetails()
        {
          if (_context.PaymentDetails == null)
          {
              return NotFound();
          }
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET: api/PaymentDetailS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetailS>> GetPaymentDetailS(int id)
        {
          if (_context.PaymentDetails == null)
          {
              return NotFound();
          }
            var paymentDetailS = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetailS == null)
            {
                return NotFound();
            }

            return paymentDetailS;
        }

        // PUT: api/PaymentDetailS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetailS(int id, PaymentDetailS paymentDetailS)
        {
            if (id != paymentDetailS.PaymentDetailId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetailS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailSExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.PaymentDetails.ToListAsync());
        }

        // POST: api/PaymentDetailS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetailS>> PostPaymentDetailS(PaymentDetailS paymentDetailS)
        {
          if (_context.PaymentDetails == null)
          {
              return Problem("Entity set 'PaymentDetailContext.PaymentDetails'  is null.");
          }
            _context.PaymentDetails.Add(paymentDetailS);
            await _context.SaveChangesAsync();

            return Ok(await _context.PaymentDetails.ToListAsync());
        }

        // DELETE: api/PaymentDetailS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetailS(int id)
        {
            if (_context.PaymentDetails == null)
            {
                return NotFound();
            }
            var paymentDetailS = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetailS == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymentDetailS);
            await _context.SaveChangesAsync();

            return Ok(await _context.PaymentDetails.ToListAsync());
        }

        private bool PaymentDetailSExists(int id)
        {
            return (_context.PaymentDetails?.Any(e => e.PaymentDetailId == id)).GetValueOrDefault();
        }
    }
}
