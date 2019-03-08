using System;
namespace UserInfo.Objects
{
    public class PageViewInfo
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }

        public PageViewInfo(UserInfoRequest request)
        {
            UserId = request.user_id;
            Name = request.name;
            Timestamp = request.timestamp;
        }

        public PageViewInfo()
        {
        }
    }
}
