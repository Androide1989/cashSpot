using cashSpot.Core.Models;
using cashSpot.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cashSpot.Web.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBudgetService budgetService;

        public IndexModel(ILogger<IndexModel> logger, IBudgetService budgetService) {
            _logger = logger;
            this.budgetService = budgetService;
        }

        public BudgetCalculation CalculatedBudged { get; set; }

        public void OnGet() {
            CalculatedBudged = budgetService.CalcBudget();
        }
    }
}
