using Refit;
using System.Threading.Tasks;
using VidyaBase.UI.HelperModels;

namespace VidyaBase.UI.API
{
    public interface IUserApi
    {
        [Get("/user/getbyid?id={id}")]
        Task<string> GetById(int id);

        [Get("/user/getbyemail?email={email}")]
        Task<string> GetByEmail(string email);

        [Get("/user/get?skip={skip}&take={take}")]
        Task<string> Get(int skip, int take);

        [Post("/user/create")]
        Task<string> Create([Body] UserHelper user);

        [Put("/user/update")]
        Task<string> Update([Body] UserHelper user);

        [Delete("/user/delete")]
        Task<string> Delete([Body] UserHelper user);
    }
}
