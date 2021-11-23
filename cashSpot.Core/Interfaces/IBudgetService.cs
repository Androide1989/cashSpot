using cashSpot.Core.Models;

namespace cashSpot.Core.Services {
    public interface IBudgetService {
        BudgetCalculation CalcBudget();
    }
}