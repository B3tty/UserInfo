using System;
using UserInfo.Objects;

namespace UserInfo.Storage
{
    public interface UserStore
    {
        void StoreInfo(PageViewInfo info);

        UserHistoryInfo GetInfo(string userId);
    }
}
