namespace ApartmentsRentalManagement1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        [Display(Name = "Payment Id")]
        public int PaymentId { get; set; }

        [StringLength(10)]
        [Display(Name = "Receipt #")]
        public string ReceiptNumber { get; set; }

        [StringLength(10)]
        [Display(Name = "Employee #")]
        public string EmployeeNumber { get; set; }

        [StringLength(10)]
        [Display(Name = "Contract #")]
        public string ContractNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Payment Date")]
        public string PaymentDate { get; set; }

        [StringLength(6)]
        public string Amount { get; set; }

        public string Notes { get; set; }
    }
}
