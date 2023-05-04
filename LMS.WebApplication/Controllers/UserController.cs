using LMS.Service.Services;
using LMS.Shared.Entities;
using LMS.Shared.Requests.Users;
using LMS.Shared.Response.User;
using LMS.Shared.Tools;
using LMS.WebApplication.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebApplication.Controllers {
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly UserService _userService;

        public UserController(UserService userService) {
            _userService = userService;
        }

        [HttpPost]
        [Route("v1/user/login")]
        public ActionResult<UserToken> Login(UserLoginRequest login) {

            var user = _userService.GetByLoginPassword(login.Login, login.Password);

            var token = JWT.GenerateJwtToken(user);

            var result = AutoConvertEntity.Convert<User, UserToken>(user, new UserToken());

            result.Token = token;

            return Ok(result);

        }


        [HttpGet]
        [Authorize]
        [Route("v1/user/{id}")]
        public ActionResult<UserResponse> Get(string id) {

            var user = _userService.GetById(id);

            return Ok(user);

        }

        [HttpPost]
        [Authorize]
        [Route("v1/user")]
        public ActionResult<UserResponse> Add(UserAddRequest request) {

            var user = _userService.Add(request);
            var result = AutoConvertEntity.Convert<User, UserResponse>(user, new UserResponse());

            return Ok(result);

        }

        [HttpPatch]
        [Authorize]
        [Route("v1/user")]
        public ActionResult<string> Update(UserUpdateRequest request) {

            _userService.Update(request);

            return Ok("Success");

        }

        [HttpDelete]
        [Authorize]
        [Route("v1/user/{id}")]
        public ActionResult<string> Delete(string id) {

            _userService.Delete(id);

            return Ok("Success");

        }


    }
}
