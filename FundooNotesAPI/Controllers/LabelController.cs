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
        private readonly ILabelBL iLabelBL;
        public LabelController(ILabelBL labelBL)
        {
            iLabelBL = labelBL;
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
                bool isSuccessfull = iLabelBL.UpdateLabelForNote(labelId, newLabel, noteId, userId);
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
        [HttpPost("AddLabel")]
        [Authorize]
        public ResponceModel<string> AddLabel(string label)
        {
            int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
            ResponceModel<string> responce = new ResponceModel<string>();
            try
            {
                bool isSuccess = iLabelBL.AddLabel(label, userId);
                if (isSuccess)
                {
                    responce.Message = "Label is added successfully!!";
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "label is not added!!";
                }
            }
            catch (Exception ex)
            {
                responce.Message = ex.Message;
                responce.IsSuccess = false;
            }
            return responce;
        }

        [HttpPost("RemoveLabel")]
        [Authorize]

        public ResponceModel<string> RemoveLabel(long labelId)
        {
            int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
            ResponceModel<string> responce = new ResponceModel<string>();
            try
            {
                bool isSuccess = iLabelBL.RemoveLabel(labelId, userId);
                if (isSuccess)
                {
                    responce.Message = "Label is removed successfully!!";
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "label is not removed!!";
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

