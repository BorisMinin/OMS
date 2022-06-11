using Microsoft.EntityFrameworkCore;
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
            return (IQueryable<Category>)this._unitOfWork.Query<Category>().ToListAsync();
        }

        public async Task<Category> GetById(int id, CancellationToken token)
        {
            var res =  await this._unitOfWork.Query<Category>()
                .FirstOrDefaultAsync(x => x.CategoryId == id, token);
            return res;
        }

        public async Task<Category> Create(CategoryDtoCreate dto, CancellationToken token)
        {
            var category = new Category()
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description
            };

            await this._unitOfWork.Add(category, token);
            await this._unitOfWork.CommitAsync(token);

            return category;
        }

        public async Task<Category> Update(int id, CategoryDtoUpdate dto, CancellationToken token)
        {
            var category = await _unitOfWork.Query<Category>().FirstOrDefaultAsync(c => c.CategoryId == id);

            category.Description = dto.Description;

            await _unitOfWork.CommitAsync(token);

            return category;
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var category = await _unitOfWork.Query<Category>().FirstOrDefaultAsync(c => c.CategoryId == id);

            if (category == null)
                throw new KeyNotFoundException();

            _unitOfWork.Delete(category, token);
            await _unitOfWork.CommitAsync(token);
        }
    }
}