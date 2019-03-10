using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserInfo.Objects;
using UserInfo.Storage;

namespace UserInfo.Api
{
    [Route("/v1")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserStore _userStore;

        public UserInfoController(IUserStore userStore)
        {
            _userStore = userStore;
        }

        [HttpPost("page")]
        public async Task<IActionResult> PostUserInfo([FromBody]UserInfoRequest request)
        {
            var info = new PageViewInfo(request);
            await _userStore.StoreInfo(info);
            return Ok();
        }

        [HttpGet("user/{user_id}")]
        public async Task<IActionResult> GetUserInfo(string user_id)
        {
            var userInfo = await _userStore.GetInfo(user_id);
            return Ok(userInfo);
        }

        [HttpDelete("USER/{user_id}")]
        public async Task<IActionResult> DeleteUserInfo(string user_id)
        {
            await _userStore.DeleteInfo(user_id);
            return Ok();
        }
    }
}