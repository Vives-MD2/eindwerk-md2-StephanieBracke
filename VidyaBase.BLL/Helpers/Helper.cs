using System;
using System.Threading.Tasks;

namespace VidyaBase.BLL
{
    public class VidyaTask<T>
    {
        public static async Task<T> Try(Func<Task<T>> operation)
        {
            try
            {
                var result = await operation.Invoke();
                return await Task.FromResult<T>(result);
            }
            catch (Exception e)
            {
                return await Task.FromException<T>(e);
            }

        }
    }
}
