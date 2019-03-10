using System;
using System.Threading.Tasks;
using UserInfo.Objects;

namespace UserInfo.Storage
{
    public interface IUserStore
    {
        Task StoreInfo(PageViewInfo info);

        Task<UserHistoryInfo> GetInfo(string userId);

        Task DeleteInfo(string user_id);
    }
}
