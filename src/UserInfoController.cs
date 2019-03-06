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

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserInfo(string userId)
        {
            var userInfo = new UserInfo();
            return Ok(userInfo);
        }
    }
}