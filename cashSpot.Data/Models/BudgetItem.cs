using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cashSpot.Data.Models {
    public class BudgetItem {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Betrag pro Monat")]
        public decimal PlannedMonthlyAmount { get; set; }
    }
}
