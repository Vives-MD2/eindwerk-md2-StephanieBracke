using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL.Databases
{
    public class CollectionOwnedGameDB : ICollectionOwnedGame
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();
        public async Task<CollectionOwnedGame> CreateAsync(CollectionOwnedGame entity)
        {
            _vidyaContext.CollectionOwnedGames.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<CollectionOwnedGame>> CreateRangeAsync(List<CollectionOwnedGame> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<CollectionOwnedGame> DeleteAsync(CollectionOwnedGame entity)
        {
            _vidyaContext.CollectionOwnedGames.Remove(_vidyaContext.CollectionOwnedGames.Single(x => x.CollectionID == entity.CollectionID && x.OwnedGamesID == entity.OwnedGamesID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<CollectionOwnedGame>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.CollectionOwnedGames.AsNoTracking().OrderBy(x => x.OwnedGamesID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<CollectionOwnedGame> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CollectionOwnedGame> GetByIdAsync(int collectionID, int ownedGameID)
        {
            return await _vidyaContext.CollectionOwnedGames.AsNoTracking().SingleOrDefaultAsync(x => x.OwnedGamesID == ownedGameID && x.CollectionID == collectionID);

        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.CollectionOwnedGames.CountAsync();
        }

        public async Task<CollectionOwnedGame> UpdateAsync(CollectionOwnedGame entity)
        {
            _vidyaContext.CollectionOwnedGames.Attach(entity);
            _vidyaContext.Entry<CollectionOwnedGame>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
