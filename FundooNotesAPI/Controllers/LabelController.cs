using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FundooNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        public readonly ILabelBL iLabelBL;
        public IConfiguration configuration;
        public LabelController(ILabelBL labelBL, IConfiguration configuration)
        {

            iLabelBL = labelBL;
            this.configuration = configuration;
        }
        [HttpPost("AddLabelToNote")]
        [Authorize]
        public ResponceModel<string> AddLabelToNote(string label, long noteId)
        {
            ResponceModel<string> responce = new ResponceModel<string>();
            int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
            try
            {
                bool isSuccessfull = iLabelBL.AddLabelToNote(label, noteId, userId);
                if (isSuccessfull)
                {
                    responce.Message = "Label added successfully!!";
                    responce.IsSuccess = true;
                }
                else
                {
                    responce.Message = "Error while adding label!!";
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

        [HttpPost("RemoveLabelFromNote")]
        [Authorize]
        public ResponceModel<string> RemoveLabelFromNote(long labelId, long noteId)
        {
            ResponceModel<string> responce = new ResponceModel<string>();
            int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
            try
            {
                bool isSuccessfull = iLabelBL.RemoveLabelFromNote(labelId, noteId, userId);
                if (isSuccessfull)
                {
                    responce.Message = "Label removed successfully!!";
                    responce.IsSuccess = true;
                }
                else
                {
                    responce.Message = "Error while removing label!!";
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
        [HttpPost("UpdateLabelForNote")]
        [Authorize]
        public ResponceModel<string> UpdateLabelForNote(long labelId, string newLabel, long noteId)
        {
            ResponceModel<string> responce = new ResponceModel<string>();
            int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
            try
            {
                bool isSuccessfull = iLabelBL.UpdateLabelForNote(labelId,newLabel,noteId, userId);
                if (isSuccessfull)
                {
                    responce.Message = "Label updated successfully!!";
                    responce.IsSuccess = true;
                }
                else
                {
                    responce.Message = "Error while updating label!!";
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

    }
}
