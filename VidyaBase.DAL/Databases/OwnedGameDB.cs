using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL.Databases
{
    public class OwnedGameDB : IOwnedGame
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();

        public async Task<OwnedGame> CreateAsync(OwnedGame entity)
        {
            _vidyaContext.OwnedGames.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<OwnedGame>> CreateRangeAsync(List<OwnedGame> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<OwnedGame> DeleteAsync(OwnedGame entity)
        {
            _vidyaContext.OwnedGames.Remove(_vidyaContext.OwnedGames.Single(x => x.ID == entity.ID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<OwnedGame>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.OwnedGames.AsNoTracking().OrderBy(x => x.ID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<OwnedGame>> GetByUserIdAsync(int userId, int skip, int take)
        {
            var list = await _vidyaContext.OwnedGames.AsNoTracking().Where(x => x.UserID == userId).OrderBy(x => x.ID).Skip(skip).Take(take).ToListAsync();
            return list;
        }

        public async Task<OwnedGame> GetByIdAsync(int id)
        {
            return await _vidyaContext.OwnedGames.AsNoTracking()
                .Include(x => x.CollectionOwnedGames)
                .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.OwnedGames.CountAsync();
        }

        public async Task<OwnedGame> UpdateAsync(OwnedGame entity)
        {
            _vidyaContext.OwnedGames.Attach(entity);
            _vidyaContext.Entry<OwnedGame>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
