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
                .Include(x => x.OrderDetails)
                .ToListAsync(token);
        }

        public async Task<Order> GetById(int id, CancellationToken token)
        {
            return await this._unitOfWork.Query<Order>()
                .Include(x => x.OrderDetails)
                .FirstOrDefaultAsync(x => x.OrderId == id, token);
        }

        public async Task<Order> Create(OrderDtoCreate orderDto, CancellationToken token)
        {

            #region Try
            //var order = new Order
            //{
            //    CustomerId = model.CustomerId,
            //    EmployeeId = model.EmployeeId
            //};

            //var details = model.OrderDetailDto.
            //    Select(d => new OrderDetail()
            //    {
            //        OrderId = d.OrderId,
            //        ProductId = d.ProductId,
            //        UnitPrice = d.UnitPrice,
            //        Quantity = d.Quantity,
            //        Discount = d.Discount
            //    });

            //order.OrderDetails = details.ToList<OrderDetail>();

            //_uow.Add(order);
            //await _uow.CommitAsync();

            //return order;
            #endregion

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


            var orderDetails = orderDto.Order_Details.Select(s => new OrderDetail()
            {
                OrderId = s.OrderId,
                ProductId = s.ProductId,
                UnitPrice = s.UnitPrice,
                Quantity = s.Quantity,
                Discount = s.Discount
            });

            order.OrderDetails = orderDetails.ToList<OrderDetail>();
            await this._unitOfWork.Add(order, token);
            await this._unitOfWork.CommitAsync(token);

            return order;
        }

        public async Task<Order> Update(int id, OrderDtoUpdate dto, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int orderId, int productId, CancellationToken token)
        {
            var details = await _unitOfWork.Query<OrderDetail>()
                .FirstOrDefaultAsync
                (
                    c => c.OrderId == orderId && c.ProductId == productId
                );

            this._unitOfWork.Delete(details, token);
            await _unitOfWork.CommitAsync(token);
        }
    }
}