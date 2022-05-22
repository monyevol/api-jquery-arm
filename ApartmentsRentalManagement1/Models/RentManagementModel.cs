using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ApartmentsRentalManagement1.Models
{
    public partial class RentManagementModel : DbContext
    {
        public RentManagementModel()
            : base("name=RentManagementModel")
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<RentalContract> RentalContracts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
