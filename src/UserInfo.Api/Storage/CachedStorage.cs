using System;
using System.Collections.Generic;
using UserInfo.Objects;
using System.Linq;

namespace UserInfo.Storage
{
    public class CachedStorage : IUserStore
    {
        private static Dictionary<string, List<PageViewInfo>> _cache;

        public CachedStorage()
        {
            _cache = new Dictionary<string, List<PageViewInfo>>();
        }


        public void StoreInfo(PageViewInfo info)
        {
            var exists = _cache.TryGetValue(info.UserId, out List<PageViewInfo> entry);
            if (exists)
            {
                _cache[info.UserId].Add(info);
            }
            else
            {
                _cache.Add(info.UserId, new List<PageViewInfo> { info });
            }
        }

        public UserHistoryInfo GetInfo(string userId)
        {
            var exists = _cache.TryGetValue(userId, out List<PageViewInfo> entry);
            var aggreg = new UserHistoryInfo();
            if (exists)
            {
                aggreg = AggregateInfo(entry);
            }
            aggreg.user_id = userId;
            return aggreg;
        }

        public void DeleteInfo(string user_id)
        {
            _cache.Remove(user_id);
        }

        private UserHistoryInfo AggregateInfo(List<PageViewInfo> userHistory)
        {
            var filtered = userHistory.Where(info => DateTime.Compare(info.TimeStamp.Date, DateTime.Today.AddDays(-7)) > 0).ToList();

            var pageCount = filtered.GroupBy(info => info.PageName).ToDictionary(gp => gp.Key, gp => gp.ToList().Count);
            var maxViews = pageCount.Values.Max();

            var daysActive = filtered.Select(info => info.TimeStamp.Date).Distinct();

            return new UserHistoryInfo
            {
                number_pages_viewed_the_last_7_days = pageCount.Keys.Count,
                time_spent_on_site_last_7_days = 0,
                number_of_days_active_last_7_days = daysActive.Count(),
                most_viewed_page_last_7_days = pageCount.First(kv => kv.Value == maxViews).Key
            };
        }
    }
}
