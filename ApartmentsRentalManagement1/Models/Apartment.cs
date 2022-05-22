namespace ApartmentsRentalManagement1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Apartment
    {
        [Display(Name = "Apartment Id")]
        public int ApartmentId { get; set; }

        [StringLength(5)]
        [Display(Name = "Unit #")]
        public string UnitNumber { get; set; }

        [StringLength(3)]
        public string Bedrooms { get; set; }

        [StringLength(3)]
        public string Bathrooms { get; set; }

        [StringLength(6)]
        [Display(Name = "Monthly Rate")]
        public string MonthlyRate { get; set; }

        [StringLength(6)]
        [Display(Name = "Deposit")]
        public string SecurityDeposit { get; set; }

        [StringLength(25)]
        [Display(Name = "Occupancy Status")]
        public string OccupancyStatus { get; set; }

        public string Residence
        {
            get
            {
                string beds = Bedrooms + " bedrooms";
                string baths = Bathrooms + " bathrooms";

                if (Bedrooms == "1")
                    beds = Bedrooms + " bedroom";
                if (Bathrooms == "1")
                    baths = Bedrooms + " bathroom";

                return UnitNumber + " - " + beds + ", " + baths + ", rent = " +
                       MonthlyRate + "/month, deposit = " +
                       SecurityDeposit + ", " + OccupancyStatus;
            }
        }
    }
}
