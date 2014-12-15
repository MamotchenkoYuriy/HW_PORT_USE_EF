using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Model.Tables;

namespace DataContext.Mapping
{
    public class ShipMap : EntityTypeConfiguration<Ship>
    {
        public ShipMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.MaxDistance).IsRequired().HasColumnName("MaxDistance");
            Property(m => m.Number).IsRequired().HasColumnName("Number");
            Property(m => m.TeamCount).IsRequired().HasColumnName("TeamCount");
            Property(m => m.Capacity).IsRequired().HasColumnName("Capacity");
            Property(m => m.CreateDate).IsRequired().HasColumnName("CreateDate");
            Property(m => m.PortId).IsOptional().HasColumnName("PortId");
            Property(m => m.CaptainId).IsOptional().HasColumnName("CaptainId");

            //Foreign Keys
            HasOptional(m => m.Captain).WithMany(m => m.Ships).HasForeignKey(m => m.CaptainId).WillCascadeOnDelete(false);
            HasOptional(m => m.Port).WithMany(m => m.Ships).HasForeignKey(m => m.PortId).WillCascadeOnDelete(false);
        }
    }
}