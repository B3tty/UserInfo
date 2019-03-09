using System;
using UserInfo.Objects;

namespace UserInfo.Storage
{
    public interface IUserStore
    {
        void StoreInfo(PageViewInfo info);

        UserHistoryInfo GetInfo(string userId);
    }
}
