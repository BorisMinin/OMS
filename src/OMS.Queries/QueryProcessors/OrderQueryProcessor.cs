using Microsoft.EntityFrameworkCore;
using OMS.API.Models.Dtos.OrderDto;
using OMS.Data.Access.DAL;
using OMS.Data.Model.Entities;
using OMS.Queries.Interfaces;

namespace OMS.Queries.QueryProcessors
{
    public class OrderQueryProcessor : IOrderQueryProcessor
    {
        private IUnitOfWork _unitOfWork;

        public OrderQueryProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<Order> Get(CancellationToken token)
        {
            return (IQueryable<Order>)this._unitOfWork.Query<Order>()
                .Include(x => x.OrderDetail)
                .ToListAsync(token);
        }

        public async Task<Order> GetById(int id, CancellationToken token)
        {
            return await this._unitOfWork.Query<Order>()
                .Include(x => x.OrderDetail)
                .FirstOrDefaultAsync(x => x.OrderId == id, token);
        }

        public async Task<Order> Create(OrderDtoCreate orderDto, CancellationToken token)
        {
            var order = new Order()
            {   
                OrderDate = orderDto.OrderDate,
                RequiredDate = orderDto.RequiredDate,
                ShippedDate = orderDto.ShippedDate,
                ShipVia = orderDto.ShipVia,
                Freight = orderDto.Freight,
                ShipName = orderDto.ShipName,
                ShipAddress = orderDto.ShipAddress,
                ShipCity = orderDto.ShipCity,
                ShipRegion = orderDto.ShipRegion,
                ShipPostalCode = orderDto.ShipPostalCode,
                ShipCountry = orderDto.ShipCountry
            };

            //var orderDetail = new OrderDetailCreate()
            //{
            //    OrderId = x.OrderId,
            //    ProductId = x.ProductId,
            //    UnitPrice = x.UnitP rice,
            //    Quantity = x.Quantity,
            //    Discount = x.Discount
            //});


            await this._unitOfWork.Add(order, token);
            await this._unitOfWork.CommitAsync(token);

            return order;
        }

        public async Task<Order> Update(int id, OrderDtoUpdate dto, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var order = await _unitOfWork.Query<Order>()
                .FirstOrDefaultAsync(c => c.OrderId == id)
                ;

            _unitOfWork.Delete(order, token);
            await _unitOfWork.CommitAsync(token);
        }
    }
}