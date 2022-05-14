using OMS.API.Models.Dtos.CategoryDto;
using OMS.Data.Access.DAL;
using OMS.Data.Model.Entities;
using OMS.Queries.Interfaces;

namespace OMS.Queries.QueryProcessors
{
    public class CategoryQueryProcessor : ICategoryQueryProcessor
    {
        private IUnitOfWork _unitOfWork;

        public CategoryQueryProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<Category> Get(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetById(int id, CancellationToken token)
        {
            //throw new NotImplementedException();
            var r = await this._unitOfWork.Query<Category>()
                .FirstOrDefault(x => x.CategoryId == id, token);
            return r;
        }

        public Task<Category> Create(CategoryDtoCreate dto, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(int id, CategoryDtoUpdate dto, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}