using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cashSpot.Data;
using cashSpot.Data.Models;

namespace cashSpot.Pages.MoneyBookings
{
    public class DeleteModel : PageModel
    {
        private readonly cashSpot.Data.CashSpotContext _context;

        public DeleteModel(cashSpot.Data.CashSpotContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MoneyBooking MoneyBooking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MoneyBooking = await _context.MoneyBooking.FirstOrDefaultAsync(m => m.Id == id);

            if (MoneyBooking == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MoneyBooking = await _context.MoneyBooking.FindAsync(id);

            if (MoneyBooking != null)
            {
                _context.MoneyBooking.Remove(MoneyBooking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
