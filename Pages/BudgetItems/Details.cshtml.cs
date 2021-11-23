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
    public class DetailsModel : PageModel
    {
        private readonly cashSpot.Data.CashSpotContext _context;

        public DetailsModel(cashSpot.Data.CashSpotContext context)
        {
            _context = context;
        }

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
    }
}
