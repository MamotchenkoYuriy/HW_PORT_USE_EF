using System.Data.Entity.ModelConfiguration;
using Model;

namespace DataContext.Mapping
{
    public class CaptainMap : EntityTypeConfiguration<Captain>
    {
        public CaptainMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasColumnName("Id");
            Property(m => m.LastName).IsRequired().HasColumnName("LastName");
            Property(m => m.FirstName).IsRequired().HasColumnName("FirstName");
            //Ignore(m => m.Ships);
            //HasMany(m => m.Ships).WithOptional(m => m.Captain).HasForeignKey(m=>m.CaptainId);
        }
    }
}