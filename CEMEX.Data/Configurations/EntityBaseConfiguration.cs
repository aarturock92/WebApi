using CEMEX.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CEMEX.Data.Configurations
{
    public class EntityBaseConfiguration<T>: EntityTypeConfiguration<T> where T: class
    {
        
    }
}
