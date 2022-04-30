using Microsoft.EntityFrameworkCore;
using OMS.Data.Model.Entities;

namespace OMS.Data.Access.Maps.EntityMaps
{
    public class CategoryMap : IMap
    {
        public void Visit(ModelBuilder builder) => builder
            .Entity<Category>()
            .ToTable("Categories")
            .HasKey(x => x.CategoryId);
    }
}