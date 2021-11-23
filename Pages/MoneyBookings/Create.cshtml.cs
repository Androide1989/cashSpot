using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using cashSpot.Data;
using cashSpot.Data.Models;

namespace cashSpot.Pages.MoneyBookings
{
    public class CreateModel : PageModel
    {
        private readonly cashSpot.Data.CashSpotContext _context;

        public CreateModel(cashSpot.Data.CashSpotContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MoneyBooking MoneyBooking { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MoneyBooking.Add(MoneyBooking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
