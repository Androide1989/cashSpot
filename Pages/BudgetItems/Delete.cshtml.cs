using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cashSpot.Data;
using cashSpot.Data.Models;

namespace cashSpot.Web.Pages.BudgetItems
{
    public class DeleteModel : PageModel
    {
        private readonly cashSpot.Data.CashSpotContext _context;

        public DeleteModel(cashSpot.Data.CashSpotContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BudgetItem = await _context.BudgetItem.FindAsync(id);

            if (BudgetItem != null)
            {
                _context.BudgetItem.Remove(BudgetItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
