using cashSpot.Data;
using cashSpot.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cashSpot.Core.Models {
    /// <summary>
    /// hold budget data from a calculation
    /// </summary>
    public class BudgetCalculation   {

        //List<MoneyBooking> MoneyBookings { get; set; }
        public List<BudgetItem> BudgetItems { get; set; }
        public decimal Balance { get; set; }
        public decimal NonAssignedMoneyBookingAmount { get; internal set; }
    }
}
