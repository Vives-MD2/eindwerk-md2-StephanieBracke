using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VidyaBase.DOMAIN
{
    public interface IGeneric<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAsync(int skip, int take);
        Task<int> GetTotalCountAsync();
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> CreateRangeAsync(List<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
