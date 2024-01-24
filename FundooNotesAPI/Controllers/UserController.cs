using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entitys;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace FundooNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        public readonly IUserBL iuserBL;
        public IConfiguration configuration;

        public UserController(IUserBL userBL, IConfiguration configuration)
        {
            iuserBL = userBL;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
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

        [HttpPost("Login")]

        public ResponceModel<string> Login(LoginModel loginModel)
        {
            ResponceModel<string> responce = new ResponceModel<string>();

            try
            {
                string token = iuserBL.Login(loginModel.UserEmail, loginModel.UserPassword);

                if (token != null)
                {
                    responce.Data = token;
                    responce.Message = "Login successful";
                }
                else
                {
                    responce.Message = "Login Unsuccessfull!!";
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

        [HttpPost("ResetPassword")]
        [Authorize]
        public ResponceModel<string> ResetPassword(string password, string confirmPassword)
        {
            ResponceModel<string> responce = new ResponceModel<string>();
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel();
            resetPasswordModel.NewPassword = password;
            resetPasswordModel.ConfirmPassword = confirmPassword;
            resetPasswordModel.UserEmail = User.FindFirstValue("Email").ToString();
            try
            {

                if (resetPasswordModel.NewPassword == resetPasswordModel.ConfirmPassword)
                {
                    var passwordResetSuccessful = iuserBL.ResetPassword(resetPasswordModel.UserEmail, resetPasswordModel.NewPassword);
                    if (passwordResetSuccessful)
                    {
                        responce.IsSuccess = true;
                        responce.Message = "Password reset successfully!!";
                    }
                    else
                    {
                        responce.IsSuccess = false;
                        responce.Message = "Password reset unsuccessfully!!";
                    }
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Password is not match. Check password!!";
                }

            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.IsSuccess = false;
            }
            return responce;
        }

       
    }
}
