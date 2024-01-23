using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Innterface;

namespace BusinessLayer.Sevice
{
    public class NoteBL : INoteBL
    {
        public readonly INoteRL inoteRL;
        public NoteBL(INoteRL noteRL)
        {
            inoteRL = noteRL;
        }
        public NoteEntity AddNote(AddNoteModel newNote, int _userId)
        {
            return inoteRL.AddNote(newNote, _userId);
        }

        public bool DeleteNote(DeleteNoteModel deleteNoteModel)
        {
            return inoteRL.DeleteNote(deleteNoteModel);
        }

        NoteEntity INoteBL.EditNote(EditNoteModel newNote,int _userId)
        {
            return inoteRL.EditNote(newNote,_userId);
        }
    }
}
