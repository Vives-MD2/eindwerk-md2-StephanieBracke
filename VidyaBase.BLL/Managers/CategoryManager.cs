using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class CategoryManager : ICategory
    {
        private readonly CategoryDB _categoryDB = new CategoryDB();

        public async Task<Category> CreateAsync(Category entity)
        {
            return await _categoryDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Category>> CreateRangeAsync(List<Category> entities)
        {
            return await _categoryDB.CreateRangeAsync(entities);
        }

        public async Task<Category> DeleteAsync(Category entity)
        {
            return await _categoryDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Category>> GetAsync(int skip, int take)
        {
            return await _categoryDB.GetAsync(skip, take);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryDB.GetByIdAsync(id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _categoryDB.GetTotalCountAsync();
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            return await _categoryDB.UpdateAsync(entity);
        }
    }
}
