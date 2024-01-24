using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entitys;
using System.Security.Claims;

namespace FundooNotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        public readonly INoteBL inoteBL;
        public IConfiguration configuration;
        public NoteController(INoteBL noteBL, IConfiguration configuration)
        {

            inoteBL = noteBL;
            this.configuration = configuration;
        }

        [HttpPost("AddNote")]
        [Authorize]
        public ResponceModel<NoteEntity> AddNote(AddNoteModel newNote)
        {
            ResponceModel<NoteEntity> responce = new ResponceModel<NoteEntity>();
            string userId = User.FindFirstValue("UserId");
            int _userId = Convert.ToInt32(userId);
            try
            {

                NoteEntity noteEntity = inoteBL.AddNote(newNote, _userId);
                if (noteEntity != null)
                {
                    responce.Data = noteEntity;
                    responce.Message = "Note added successfully!!";
                }
                else
                {
                    responce.Message = "Note is not added!!";
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
        [HttpDelete("DeleteNote")]
        [Authorize]
        public ResponceModel<NoteEntity> DeleteNote(int noteId)
        {
            ResponceModel<NoteEntity> responce = new ResponceModel<NoteEntity>();
            string userId = User.FindFirstValue("UserId");
            int _userId = Convert.ToInt32(userId);
            try
            {
                bool isDeleted = inoteBL.DeleteNote(noteId, _userId);
                if (isDeleted)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Note deleted successfully!!";
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Note not deleted!!";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
        [HttpPut("EditNote")]
        [Authorize]
        public ResponceModel<NoteEntity> EditNote(long noteId, EditNoteModel editNote)
        {
            string userId = User.FindFirstValue("UserId");
            int _userId = Convert.ToInt32(userId);
            ResponceModel<NoteEntity> responce = new ResponceModel<NoteEntity>();
            try
            {
                NoteEntity noteEntity = inoteBL.EditNote(editNote, _userId, noteId);
                if (noteEntity != null)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Note edit successfully!!";
                    responce.Data = noteEntity;
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Note not edit successfully!!";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        [HttpPut("Pin-Unpin")]
        [Authorize]

        public ResponceModel<NoteEntity> Pin_Unpin(long noteId)
        {
            string userId = User.FindFirstValue("UserId");
            int _userId = Convert.ToInt32(userId);
            ResponceModel<NoteEntity> responce = new ResponceModel<NoteEntity>();
            try
            {
                bool isSuccess = inoteBL.Pin_Unpin(_userId, noteId);
                if (isSuccess)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Pin-Unpin operation successfull!!";

                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Pin-Unpin operation unsccessfull!!";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }
        [HttpPut("Trash-UnTrash")]
        [Authorize]
        public ResponceModel<NoteEntity> Trash_UnTrash(long noteId)
        {
            string userId = User.FindFirstValue("UserId");
            int _userId = Convert.ToInt32(userId);
            ResponceModel<NoteEntity> responce = new ResponceModel<NoteEntity>();
            try
            {
                bool isSuccess = inoteBL.Trash_UnTrash(_userId, noteId);
                if (isSuccess)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Trash-UnTrash operation successfull!!";

                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Trash-UnTrash operation unsccessfull!!";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        [HttpPut("Archive-UnArchive")]
        [Authorize]
        public ResponceModel<NoteEntity> Archive_UnArchive(long noteId)
        {
            string userId = User.FindFirstValue("UserId");
            int _userId = Convert.ToInt32(userId);
            ResponceModel<NoteEntity> responce = new ResponceModel<NoteEntity>();
            try
            {
                bool isSuccess = inoteBL.Archive_UnArchive(_userId, noteId);
                if (isSuccess)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Archive-UnArchive operation successfull!!";

                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Archive-UnArchive operation unsccessfull!!";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        [HttpPut("ChangeColor")]
        [Authorize]
        public ResponceModel<NoteEntity> ChangeColor(long noteId,string color)
        {
            string userId = User.FindFirstValue("UserId");
            int _userId = Convert.ToInt32(userId);
            ResponceModel<NoteEntity> responce = new ResponceModel<NoteEntity>();
            try
            {
                bool isSuccess = inoteBL.ChangeColor(_userId, noteId,color);
                if (isSuccess)
                {
                    responce.IsSuccess = true;
                    responce.Message = "Color change successfully!!";
                }
                else
                {
                    responce.IsSuccess = false;
                    responce.Message = "Color not change!!";
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            return responce;
        }

        [HttpGet("GetAllNotes")]
        [Authorize]
        public IActionResult GetAllNotes ()
        {
            int userId = Convert.ToInt32(User.FindFirstValue("UserId"));
       
            try
            {
                IEnumerable<NoteEntity> allNotes = inoteBL.GetAllNotes(userId);
                if (allNotes != null)
                {
                    return Ok(new ResponceModel<IEnumerable<NoteEntity>> { IsSuccess= true, Message="Successfully get all data!!", Data=allNotes});
                }
                else
                {
                    return BadRequest(new ResponceModel<string> { IsSuccess = false, Message = "UnSuccessfull for geting all data!!", Data = null });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }                    
        }
    }
}
