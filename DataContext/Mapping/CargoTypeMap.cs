using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Model;

namespace DataContext.Mapping
{
    public class CargoTypeMap : EntityTypeConfiguration<CargoType>
    {
        public CargoTypeMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.TypeName).IsRequired().HasColumnName("TypeName");
        }
    }
}