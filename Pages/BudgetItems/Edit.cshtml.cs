using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cashSpot.Data;
using cashSpot.Data.Models;

namespace cashSpot.Web.Pages.BudgetItems
{
    public class EditModel : PageModel
    {
        private readonly cashSpot.Data.CashSpotContext _context;

        public EditModel(cashSpot.Data.CashSpotContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BudgetItem BudgetItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BudgetItem = await _context.BudgetItem.FirstOrDefaultAsync(m => m.Id == id);

            if (BudgetItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BudgetItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetItemExists(BudgetItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BudgetItemExists(int id)
        {
            return _context.BudgetItem.Any(e => e.Id == id);
        }
    }
}
