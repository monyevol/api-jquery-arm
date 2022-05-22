namespace ApartmentsRentalManagement1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RentalContract
    {
        [Display(Name = "Rent Contract Id")]
        public int RentalContractId { get; set; }

        [StringLength(10)]
        [Display(Name = "Contract #")]
        public string ContractNumber { get; set; }

        [StringLength(10)]
        [Display(Name = "Employee #")]
        public string EmployeeNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Contract Date")]
        public string ContractDate { get; set; }

        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(25)]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [StringLength(3)]
        [Display(Name = "Children")]
        public string NumberOfChildren { get; set; }

        [StringLength(6)]
        [Display(Name = "Unit #")]
        public string UnitNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Rent Start Date")]
        public string RentStartDate { get; set; }

        public string Description
        {
            get
            {
                return ContractNumber + " - " + FirstName + " " + LastName + " (renting since " + RentStartDate + ")";
            }
        }
    }
}
