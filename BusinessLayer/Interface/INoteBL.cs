using CommonLayer.Model;
using RepositoryLayer.Entitys;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        NoteEntity AddNote(AddNoteModel newNote, int _userId);
        bool DeleteNote(DeleteNoteModel deleteNoteModel);

        NoteEntity EditNote(EditNoteModel newNote, int _userId);
    }
}
