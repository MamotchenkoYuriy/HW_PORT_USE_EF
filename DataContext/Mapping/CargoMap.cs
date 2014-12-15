using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Model;

namespace DataContext.Mapping
{
    public class CargoMap : EntityTypeConfiguration<Cargo>
    {
        public CargoMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.InsurancePrice).IsRequired().HasColumnName("InsurancePrice");
            Property(m => m.Price).IsRequired().HasColumnName("Price");
            Property(m => m.Weight).IsRequired().HasColumnName("Weight");
            Property(m => m.Number).IsRequired().HasColumnName("Number");
            Property(m => m.TripId).IsOptional().HasColumnName("TripId");
            Property(m => m.CargoTypeId).IsOptional().HasColumnName("CargoTypeId");



            HasOptional(m=>m.CargoType).WithMany(m=>m.Cargoes).HasForeignKey(m=>m.CargoTypeId).WillCascadeOnDelete(false);
            HasOptional(m => m.Trip).WithMany(m=>m.Cargoes).HasForeignKey(m => m.TripId).WillCascadeOnDelete(false);
        }
    }
}