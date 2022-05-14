using OMS.API.Models.Dtos.CategoryDto;
using OMS.Data.Model.Entities;
using OMS.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Queries.QueryProcessors
{
    public class CategoryQueryProcessor : ICategoryQueryProcessor
    {
        public Task<Category> Create(CategoryDtoCreate dto, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> Get(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(int id, CategoryDtoUpdate dto, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}