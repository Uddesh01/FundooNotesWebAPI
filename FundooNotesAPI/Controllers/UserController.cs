using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;

namespace FundooNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        public readonly IUserBL iuserBL;
        public UserController(IUserBL userBL)
        {
            iuserBL = userBL;
        }

        [HttpPost("register")]
        public ResponceModel<UserEntity> Register(UserModel newUser)
        {
            ResponceModel<UserEntity> responce = new ResponceModel<UserEntity>();
            try
            {

                UserEntity userEntity = iuserBL.Register(newUser);
                if (userEntity != null)
                {
                    responce.Data = userEntity;
                    responce.Message = "Registration successfull!!";
                }
                else
                {
                    responce.Message = "Registration Unsuccessfull!!";
                    responce.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.IsSuccess = false;
            }
            return responce;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                iuserBL.Login(loginModel.UserEmail, loginModel.UserPassword);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("resetPassword")]
        public IActionResult ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                var passwordResetSuccessful = iuserBL.ResetPassword(resetPasswordModel.UserEmail, resetPasswordModel.NewPassword);
                if (passwordResetSuccessful)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(new { Message = "Password reset failed." });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
