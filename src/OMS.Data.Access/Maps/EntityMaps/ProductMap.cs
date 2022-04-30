using Microsoft.EntityFrameworkCore;
using OMS.Data.Model.Entities;

namespace OMS.Data.Access.Maps.EntityMaps
{
    public class ProductMap : IMap
    {
        public void Visit(ModelBuilder builder) => builder
            .Entity<Product>()
            .ToTable("Products")
            .HasOne<Category>(one => one.Category)
            .WithMany(many => many.Products)
            .HasForeignKey(fk => fk.CategoryId);
    }
}