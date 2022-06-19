using Microsoft.AspNetCore.Mvc;
using OMS.API.Models.Dtos.OrderDto;
using OMS.API.Models.OrderDetailDto;
using OMS.Data.Model.Entities;
using OMS.Maps;
using OMS.Queries.Interfaces;

namespace OMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderQueryProcessor _queryProcessor;
        private readonly IAutoMapper _autoMapper;

        public OrderController(IOrderQueryProcessor queryProcessor, IAutoMapper autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }

        /// <summary>
        /// возвращает запись OrderDetails по идентификатору
        /// </summary>
        /// <param name="id">идентификатор детайлей заказа</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<OrderDtoGet> GetOrderDetail(int id, CancellationToken token)
        {
            var result = await this._queryProcessor.GetById(id, token);
            return this._autoMapper.Map<OrderDtoGet>(result);
        }

        /// <summary>
        /// удаляет запись OrderDetails по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task DeleteOrderDetail(int id, CancellationToken token)
        {
            await this._queryProcessor.Delete(id, token);
        }
    }
}