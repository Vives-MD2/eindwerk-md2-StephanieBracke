
using System.Threading.Tasks;
namespace VidyaBase.DOMAIN.Contracts
{
    public interface IUserAchievement : IGeneric<UserAchievement>
    {
        Task<UserAchievement> GetByIdAsync(int userID, int achievementID);
    }
}
