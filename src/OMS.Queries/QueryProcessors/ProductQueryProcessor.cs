using Microsoft.EntityFrameworkCore;
using OMS.API.Models.Dtos.ProductDto;
using OMS.Data.Access.DAL;
using OMS.Data.Model.Entities;
using OMS.Queries.Interfaces;

namespace OMS.Queries.QueryProcessors
{
    public class ProductQueryProcessor : IProductQueryProcessor
    {
        private IUnitOfWork _unitOfWork;

        public ProductQueryProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<Product> Get(CancellationToken token)
        {
            return (IQueryable<Product>)this._unitOfWork.Query<Product>().ToListAsync();
        }

        public async Task<Product> GetById(int id, CancellationToken token)
        {
            return await this._unitOfWork.Query<Product>()
                .FirstOrDefaultAsync(x => x.ProductId == id, token);
        }

        public async Task<Product> Create(ProductDtoCreate dto, CancellationToken token)
        {
            var product = new Product()
            {
                CategoryId = dto.CategoryId,
                ProductName = dto.ProductName,
                UnitPrice = dto.UnitPrice,
                QuantityPerUnit = dto.QuantityPerUnit,
                Discontinued = dto.Discontinued,
                UnitsInStock = dto.UnitsInStock,
                UnitsOnOrder = dto.UnitsOnOrder,
                ReorderLevel = dto.ReorderLevel
            };

            await this._unitOfWork.Add(product, token);
            await this._unitOfWork.CommitAsync(token);

            return product;
        }

        public async Task<Product> Update(int id, ProductDtoUpdate dto, CancellationToken token)
        {
            var product = await this._unitOfWork.Query<Product>().FirstOrDefaultAsync(c => c.ProductId == id, token);

            product.QuantityPerUnit = dto.QuantityPerUnit;
            product.UnitPrice = dto.UnitPrice;
            product.UnitsInStock = dto.UnitsInStock;
            product.UnitsOnOrder = dto.UnitsOnOrder;
            product.ReorderLevel = dto.ReorderLevel;
            product.Discontinued = dto.Discontinued;

            await _unitOfWork.CommitAsync(token);

            return product;
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var product = await this._unitOfWork.Query<Product>().FirstOrDefaultAsync(p => p.ProductId == id, token);

            _unitOfWork.Delete(product, token);
            await _unitOfWork.CommitAsync(token);
        }
    }
}