using Microsoft.EntityFrameworkCore;
using OMS.Data.Model.Entities;

namespace OMS.Data.Access.Maps.EntityMaps
{
    public class OrderMap : IMap
    {
        public void Visit(ModelBuilder builder) => builder.Entity<Order>().ToTable("Orders").HasKey(x => x.OrderId);
    }
}