using OMS.API.Models.Dtos.CategoryDto;
using OMS.Data.Model.Entities;

namespace OMS.Queries.Interfaces
{
    public interface ICategoryQueryProcessor
    {
        IQueryable<Category> Get(CancellationToken token);
        Task<Category> GetById(int id, CancellationToken token);
        Task<Category> Create(CategoryDtoCreate dto, CancellationToken token);
        Task<Category> Update(int id, CategoryDtoUpdate dto, CancellationToken token);
        Task Delete(int id, CancellationToken token);
    }
}