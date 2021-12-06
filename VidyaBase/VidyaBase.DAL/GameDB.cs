using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL
{
    class GameDB : IGame
    {
        Task<Game> IGeneric<Game>.CreateAsync(Game entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Game>> IGeneric<Game>.CreateRangeAsync(List<Game> entities)
        {
            throw new NotImplementedException();
        }

        Task<Game> IGeneric<Game>.DeleteAsync(Game entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Game>> IGeneric<Game>.GetAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        Task<Game> IGeneric<Game>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> IGeneric<Game>.GetTotalCountAsync()
        {
            throw new NotImplementedException();
        }

        Task<Game> IGeneric<Game>.UpdateAsync(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}
