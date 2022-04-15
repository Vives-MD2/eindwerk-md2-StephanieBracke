using System.Collections.Generic;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class OwnedGameManager : IOwnedGame
    {
        private readonly OwnedGameDB _ownedGameDB = new OwnedGameDB();

        public async Task<OwnedGame> CreateAsync(OwnedGame entity)
        {
            return await _ownedGameDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<OwnedGame>> CreateRangeAsync(List<OwnedGame> entities)
        {
            return await _ownedGameDB.CreateRangeAsync(entities);
        }

        public async Task<OwnedGame> DeleteAsync(OwnedGame entity)
        {
            return await _ownedGameDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<OwnedGame>> GetAsync(int skip, int take)
        {
            return await _ownedGameDB.GetAsync(skip, take);
        }
        public async Task<IEnumerable<OwnedGame>> GetByUserIdAsync(int userId, int skip, int take)
        {
            return await _ownedGameDB.GetByUserIdAsync(userId, skip, take);
        }

        public async Task<OwnedGame> GetByIdAsync(int id)
        {
            return await _ownedGameDB.GetByIdAsync(id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _ownedGameDB.GetTotalCountAsync();
        }

        public async Task<OwnedGame> UpdateAsync(OwnedGame entity)
        {
            return await _ownedGameDB.UpdateAsync(entity);
        }
    }
}
