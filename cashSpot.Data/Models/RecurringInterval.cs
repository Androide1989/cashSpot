using System.ComponentModel.DataAnnotations;

namespace cashSpot.Data.Models {
    public enum RecurringInterval {
        [Display(Name = "Keine Fixkosten")]

        None,
        [Display(Name = "Täglich")]
        Daily,
        [Display(Name = "Wöchentlich")]

        Weekly,
        [Display(Name = "Montalich")]

        Monthly,
        [Display(Name = "Jährlich")]

        Yearly
        //Biennial -> use multiplier
    }
}