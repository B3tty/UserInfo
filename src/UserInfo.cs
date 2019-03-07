using System;
namespace UserInfo.Api
{
    public class UserInfo
    {
        public string user_id { get; set; }
        public int number_pages_viewed_the_last_7_days { get; set; }
        public int time_spent_on_site_last_7_days { get; set; }
        public int number_of_days_active_last_7_days { get; set; }
        public string most_viewed_page_last_7_days { get; set; }

        public UserInfo()
        {

        }
    }
}
