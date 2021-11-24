using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cashSpot.Data.Models {
    public class BudgetItem {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Betrag pro Monat (geplant)")]
        public decimal PlannedMonthlyAmount { get; set; }
        [Display(Name = "Tatsächlicher Betrag")]
        [NotMapped]
        public decimal ActualAmount { get; set; }
        [Display(Name = "Differenz")]
        [NotMapped]
        public decimal AmountDifference => PlannedMonthlyAmount - ActualAmount;
        
        [InverseProperty(nameof(MoneyBooking.BudgetItem))]
        public List<MoneyBooking> MoneyBookings { get; set; }

        [Display(Name = "Pflichtposten")]
        public bool Mandatory { get; set; }
    }
}
