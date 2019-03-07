using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UserInfo.Api
{
    [Route("/v1")]
    public class UserInfoController : ControllerBase
    {
        [HttpPost("page")]
        public async Task<IActionResult> PostUserInfo([FromBody]UserInfoRequest request)
        {
            return Ok();
        }

        [HttpGet("user/{user_id}")]
        public async Task<IActionResult> GetUserInfo(string user_id)
        {
            var userInfo = new UserInfo { user_id = user_id };
            return Ok(userInfo);
        }
    }
}