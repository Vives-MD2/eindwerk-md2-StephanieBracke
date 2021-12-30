using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class CollectionManager : ICollection
    {
        private readonly CollectionDB _collectionDB = new CollectionDB();

        public async Task<Collection> CreateAsync(Collection entity)
        {
            return await _collectionDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Collection>> CreateRangeAsync(List<Collection> entities)
        {
            return await _collectionDB.CreateRangeAsync(entities);
        }

        public async Task<Collection> DeleteAsync(Collection entity)
        {
            return await _collectionDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Collection>> GetAsync(int skip, int take)
        {
            return await _collectionDB.GetAsync(skip, take);
        }

        public async Task<Collection> GetByIdAsync(int id)
        {
            return await _collectionDB.GetByIdAsync(id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _collectionDB.GetTotalCountAsync();
        }

        public async Task<Collection> UpdateAsync(Collection entity)
        {
            return await _collectionDB.UpdateAsync(entity);
        }
    }
}
