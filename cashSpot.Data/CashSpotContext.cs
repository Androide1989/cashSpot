using cashSpot.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cashSpot.Data {
    public class CashSpotContext : DbContext {
        public DbSet<BudgetItem> BudgetItem { get; set; }
        public DbSet<MoneyBooking> MoneyBooking { get; set; }
        public CashSpotContext() { }


        public CashSpotContext(DbContextOptions options) : base(options) {

        }
    }
}
