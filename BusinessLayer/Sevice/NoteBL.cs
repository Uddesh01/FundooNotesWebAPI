using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entitys;
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

        public bool DeleteNote(long noteId, int _userId)
        {
            return inoteRL.DeleteNote(noteId, _userId);
        }

        bool INoteBL.Archive_UnArchive(int _userId, long noteId)
        {
            return inoteRL.Archive_UnArchive(_userId, noteId);
        }

        NoteEntity INoteBL.EditNote(EditNoteModel editNote, int _userId, long noteId)
        {
            return inoteRL.EditNote(editNote, _userId, noteId);
        }

        bool INoteBL.Pin_Unpin(int _userId, long noteId)
        {
            return inoteRL.Pin_Unpin(_userId, noteId);
        }

        bool INoteBL.Trash_UnTrash(int _userId, long noteId)
        {
            return inoteRL.Trash_UnTrash(_userId, noteId);
        }

        bool INoteBL.ChangeColor(int _userId, long noteId, string color)
        {
            return inoteRL.ChangeColor(_userId, noteId, color);
        }

        IEnumerable<NoteEntity> INoteBL.GetAllNotes(int _userId)
        {
            return inoteRL.GetAllNotes(_userId);
        }
        public IEnumerable<NoteEntity> GetAllNotesByLabelName(long labelId, int userId)
        {
            return inoteRL.GetAllNotesByLabelName(labelId, userId);
        }
    }
}
