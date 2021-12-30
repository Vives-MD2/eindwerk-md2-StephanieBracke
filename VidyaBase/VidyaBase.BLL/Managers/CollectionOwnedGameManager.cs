using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class CollectionOwnedGameManager : ICollectionOwnedGame
    {
        private readonly CollectionOwnedGameDB _collectionOwnedGameDB = new CollectionOwnedGameDB();

        public async Task<CollectionOwnedGame> CreateAsync(CollectionOwnedGame entity)
        {
            return await _collectionOwnedGameDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<CollectionOwnedGame>> CreateRangeAsync(List<CollectionOwnedGame> entities)
        {
            return await _collectionOwnedGameDB.CreateRangeAsync(entities);
        }

        public async Task<CollectionOwnedGame> DeleteAsync(CollectionOwnedGame entity)
        {
            return await _collectionOwnedGameDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<CollectionOwnedGame>> GetAsync(int skip, int take)
        {
            return await _collectionOwnedGameDB.GetAsync(skip, take);
        }

        public async Task<CollectionOwnedGame> GetByIdAsync(int collectionID, int ownedGameID)
        {
            return await _collectionOwnedGameDB.GetByIdAsync(collectionID, ownedGameID);
        }

        public async Task<CollectionOwnedGame> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _collectionOwnedGameDB.GetTotalCountAsync();
        }

        public async Task<CollectionOwnedGame> UpdateAsync(CollectionOwnedGame entity)
        {
            return await _collectionOwnedGameDB.UpdateAsync(entity);
        }
    }
}
