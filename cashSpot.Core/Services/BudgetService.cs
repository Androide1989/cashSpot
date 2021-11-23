using cashSpot.Core.Models;
using cashSpot.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cashSpot.Core.Services {
    public class BudgetService  : IBudgetService{

        private readonly CashSpotContext context;
        public BudgetService(CashSpotContext context) {
            this.context = context;
        }

        public BudgetCalculation CalcBudget() {
            //TODO: consider interval and only load bookings accordingly
            var budgetItems = context.BudgetItem.Include(x => x.MoneyBookings).ToList();
            foreach(var budgetItem in budgetItems) {
                budgetItem.ActualAmount = budgetItem.MoneyBookings?.Sum(x => x.Amount) ?? 0;
            }
            var nonAssignedMoneyBookingAmount = context.MoneyBooking.Where(x => x.BudgetItemId == null).Sum(x => x.Amount);
            var calculation = new BudgetCalculation() {
                BudgetItems = budgetItems,
                 Balance = budgetItems.Sum(x => x.ActualAmount) + nonAssignedMoneyBookingAmount,
                 NonAssignedMoneyBookingAmount = nonAssignedMoneyBookingAmount
            };
            return calculation;
        }
    }
}
