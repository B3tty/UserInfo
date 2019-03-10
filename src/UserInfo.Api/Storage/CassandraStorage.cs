using System;
using System.Collections.Generic;
using System.Linq;
using Cassandra;
using UserInfo.Objects;

namespace UserInfo.Storage
{
    public class CassandraStorage : IUserStore
    {
        private static ISession _session;
        private readonly PreparedStatement _insertStatement;
        private readonly PreparedStatement _selectStatement;
        private readonly PreparedStatement _deleteStatement;

        public CassandraStorage(ISession session)
        {
            _session = session;
            _insertStatement = _session.Prepare("INSERT INTO mk.page_info_by_user (user_id, time_stamp, page_name) VALUES (?, ?, ?)");
            _selectStatement = _session.Prepare("SELECT time_stamp, page_name FROM mk.page_info_by_user WHERE user_id = ?");
            _deleteStatement = _session.Prepare("DELETE FROM mk.page_info_by_user WHERE user_id = ?");
        }


        public void StoreInfo(PageViewInfo info)
        {
            _session.ExecuteAsync(_insertStatement.Bind(info.UserId, info.TimeStamp, info.PageName));
        }

        public UserHistoryInfo GetInfo(string userId)
        {
            var recentRows = _session.Execute(_selectStatement.Bind(userId)).GetRows().ToList();

            var aggreg = new UserHistoryInfo();
            if (recentRows.Count > 0)
            {
                aggreg = AggregateInfo(recentRows);
            }
            aggreg.user_id = userId;
            return aggreg;
        }

        public void DeleteInfo(string userId)
        {
            _session.Execute(_deleteStatement.Bind(userId));
        }

        private UserHistoryInfo AggregateInfo(List<Row> rows)
        {
            var filtered = rows.Where(row => DateTime.Compare(row.GetValue<DateTime>("time_stamp"), DateTime.Today.AddDays(-7)) > 0).ToList();

            var pageCount = filtered.GroupBy(row => row.GetValue<string>("page_name")).ToDictionary(gp => gp.Key, gp => gp.ToList().Count);
            var maxViews = pageCount.Values.Max();

            var daysActive = filtered.Select(row => row.GetValue<DateTime>("time_stamp").Date).Distinct();

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
