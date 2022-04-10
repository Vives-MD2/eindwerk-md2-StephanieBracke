using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL
{
    public class UserDB : IUser
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();
        public async Task<User> CreateAsync(User entity)
        {
            Console.WriteLine("adding {0}", entity.Email);
            _vidyaContext.Users.Add(entity);
            Console.WriteLine("created {0}", entity.Email);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<User>> CreateRangeAsync(List<User> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<User> DeleteAsync(User entity)
        {
            _vidyaContext.Users.Remove(_vidyaContext.Users.Single(x => x.ID == entity.ID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<User>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.Users.AsNoTracking().OrderBy(x => x.ID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _vidyaContext.Users.AsNoTracking()
            .Include(x => x.Wishlists)
            .Include(x => x.Collections)
            .SingleOrDefaultAsync(x => x.ID == id);
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _vidyaContext.Users.AsNoTracking()
            //.Include(x => x.Wishlists)
            //.Include(x => x.Collections)
            .SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.Users.CountAsync();
        }

        public async Task<User> UpdateAsync(User entity)
        {
            _vidyaContext.Users.Attach(entity);
            _vidyaContext.Entry<User>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
