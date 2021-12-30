using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL.Databases
{
    public class AchievementDB : IAchievement
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();

        public async Task<Achievement> CreateAsync(Achievement entity)
        {
            _vidyaContext.Achievements.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Achievement>> CreateRangeAsync(List<Achievement> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<Achievement> DeleteAsync(Achievement entity)
        {
            _vidyaContext.Achievements.Remove(_vidyaContext.Achievements.Single(x => x.ID == entity.ID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Achievement>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.Achievements.AsNoTracking().OrderBy(x => x.ID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Achievement> GetByIdAsync(int id)
        {
            return await _vidyaContext.Achievements.AsNoTracking()
            .Include(x => x.UserAchievements)
            .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.Achievements.CountAsync();
        }

        public async Task<Achievement> UpdateAsync(Achievement entity)
        {
            _vidyaContext.Achievements.Attach(entity);
            _vidyaContext.Entry<Achievement>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
