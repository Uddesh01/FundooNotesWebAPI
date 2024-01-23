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

                NoteEntity noteEntity = inoteBL.AddNote(newNote,_userId);
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
        public ResponceModel<NoteEntity> DeleteNote(DeleteNoteModel deleteNoteModel)
        {
            ResponceModel<NoteEntity> responce = new ResponceModel<NoteEntity>();
            try
            {
               bool isDeleted = inoteBL.DeleteNote(deleteNoteModel);
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
            catch(Exception ex) 
            {
                    responce.IsSuccess=false;
                    responce.Message = ex.Message;
            }
            return responce;
        }
        [HttpPut("EditNote")]
        [Authorize]
        public ResponceModel<NoteEntity> EditNote(EditNoteModel newNote)
        {
            string userId = User.FindFirstValue("UserId");
            int _userId = Convert.ToInt32(userId);
            ResponceModel<NoteEntity> responce = new ResponceModel<NoteEntity>();
            try
            {
                NoteEntity noteEntity = inoteBL.EditNote(newNote,_userId);
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
            catch(Exception ex)
            {
                responce.IsSuccess=false;
                responce.Message=ex.Message;
            }
            return responce;
        }
    }
}
