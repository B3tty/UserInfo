using System;
namespace UserInfo.Objects
{
    public class PageViewInfo
    {
        public string UserId { get; set; }
        public string PageName { get; set; }
        public DateTime DateStamp { get; set; }

        public PageViewInfo(UserInfoRequest request)
        {
            UserId = request.user_id;
            PageName = request.name;
            DateStamp = request.timestamp.Date;
        }

        public PageViewInfo()
        {
        }
    }
}
