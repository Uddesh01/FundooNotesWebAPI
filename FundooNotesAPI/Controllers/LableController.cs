using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace FundooNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LableController : ControllerBase
    {
        public readonly ILabelBL ilabelBL;
        public IConfiguration configuration;
        public LableController(ILabelBL labelBL, IConfiguration configuration)
        {

            ilabelBL = labelBL;
            this.configuration = configuration;
        }

        [HttpPost("AddLabel")]
        [Authorize]
        public ResponceModel<string> AddLabel(long noteId, string label)
        {
            ResponceModel<string> responce = new ResponceModel<string>();
            int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
            try
            {
                bool isSuccessfull = ilabelBL.AddLabel(noteId, userId, label);
                if (isSuccessfull)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Label added successfully!!";
                }
                else
                {
                    responce.Message = "Label is not added!!";
                    responce.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
        [HttpPut("UpdateLabel")]
        [Authorize]
        public ResponceModel<string> UpdateLabel(long noteId, string newLabel,long labelId)
        {
            ResponceModel<string> responce = new ResponceModel<string>();
            int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
            try
            {
                bool isSuccessfull = ilabelBL.UpdateLabel(noteId, userId, newLabel,labelId);
                if (isSuccessfull)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Label updated successfully!!";
                }
                else
                {
                    responce.Message = "Label is not updated!!";
                    responce.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
        [HttpDelete("RemoveLabel")]
        [Authorize]
        public ResponceModel<string> RemoveLabel(long noteId,long labelId)
        {
            int userId = Convert.ToInt32(User.FindFirstValue("UserID"));
            ResponceModel<string> responce = new ResponceModel<string>();
            try
            {
                bool isSuccessfull = ilabelBL.RemoveLabel(noteId, userId,labelId);
                if (isSuccessfull)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Label removed successfully!!";
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Label is not removed!!";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
    }
}
