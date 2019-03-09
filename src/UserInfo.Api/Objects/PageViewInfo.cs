using System;
namespace UserInfo.Objects
{
    public class PageViewInfo
    {
        public string UserId { get; set; }
        public string PageName { get; set; }
        public DateTime TimeStamp { get; set; }

        public PageViewInfo(UserInfoRequest request)
        {
            UserId = request.user_id;
            PageName = request.name;
            TimeStamp = request.timestamp;
        }

        public PageViewInfo()
        {
        }
    }
}
