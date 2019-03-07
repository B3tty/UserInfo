using System;
namespace UserInfo.Api
{
    public class UserInfoRequest
    {
        public string user_id { get; set; }
        public string name { get; set; }
        public DateTime timestamp { get; set; }

        public UserInfoRequest()
        {
        }
    }
}
