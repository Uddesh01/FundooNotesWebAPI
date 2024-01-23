using CommonLayer.Model;
using RepositoryLayer.Entitys;

namespace RepositoryLayer.Innterface
{
    public interface INoteRL
    {
        NoteEntity AddNote(AddNoteModel newNote, int _userId);
        bool DeleteNote(DeleteNoteModel deleteNote);
        NoteEntity EditNote(EditNoteModel newNote, int _userId);
    }
}
