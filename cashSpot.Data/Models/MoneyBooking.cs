using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cashSpot.Data.Models {
    public class MoneyBooking {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Beschreibung")]
        public string Description { get; set; }
        [Display(Name = "Betrag")]

        public decimal Amount { get; set; }
        [Display(Name = "Fixkosten-Intervall")]

        public RecurringInterval RecurringInterval { get; set; }
        /// <summary>
        /// for example set this to 3 and RecuringInterval to monthly to make this a recurring booking due all three months
        /// </summary>
        [Display(Name ="Fixkosten-Intervall-Multiplikator")]
        public int? ReccurdingIntervalMultiplier { get; set; }
        [Display(Name = "Fixkosten")]

        public bool IsReccuring => RecurringInterval != RecurringInterval.None;

        public int? BudgetItemId { get; set; }
        [ForeignKey(nameof(BudgetItemId))]
        public BudgetItem BudgetItem { get; set; }
    }
}
