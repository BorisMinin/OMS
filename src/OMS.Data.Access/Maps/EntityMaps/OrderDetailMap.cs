using Microsoft.EntityFrameworkCore;
using OMS.Data.Model.Entities;

namespace OMS.Data.Access.Maps.EntityMaps
{
    public class OrderDetailMap : IMap
    {
        public void Visit(ModelBuilder builder) => builder.Entity<OrderDetail>().ToTable("OrderDetails");
    }
}