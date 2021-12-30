using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class GameCategoryManager : IGameCategory
    {
        private readonly GameCategoryDB _gameCategoryDB = new GameCategoryDB();

        public async Task<GameCategory> CreateAsync(GameCategory entity)
        {
            return await _gameCategoryDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<GameCategory>> CreateRangeAsync(List<GameCategory> entities)
        {
            return await _gameCategoryDB.CreateRangeAsync(entities);
        }

        public async Task<GameCategory> DeleteAsync(GameCategory entity)
        {
            return await _gameCategoryDB .DeleteAsync(entity);
        }

        public async Task<IEnumerable<GameCategory>> GetAsync(int skip, int take)
        {
            return await _gameCategoryDB.GetAsync(skip, take);
        }

        public async Task<GameCategory> GetByIdAsync(int gameID, int categoryID)
        {
            return await _gameCategoryDB .GetByIdAsync(gameID, categoryID);
        }

        public async Task<GameCategory> GetByIdAsync(int id)
        {
            return await _gameCategoryDB .GetByIdAsync(id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GameCategory> UpdateAsync(GameCategory entity)
        {
            return await _gameCategoryDB.UpdateAsync(entity);
        }
    }
}
