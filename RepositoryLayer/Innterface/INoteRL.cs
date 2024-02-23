using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entitys;

namespace RepositoryLayer.Innterface
{
    public interface INoteRL
    {
        NoteEntity AddNote(AddNoteModel newNote, int _userId);
        bool DeleteNote(long noteId, int _userId);
        NoteEntity EditNote(EditNoteModel editNote, int _userId,long noteId);
        bool Pin_Unpin( int _userId, long noteId);
        bool Archive_UnArchive(int _userId, long noteId);
        bool Trash_UnTrash(int _userId, long noteId);
        bool ChangeColor(int _userId, long noteId, string color);
        IEnumerable<NoteEntity> GetAllNotes(int _userId);
        IEnumerable<NoteEntity> GetAllNotesUsingRedis(int _userId);
        IEnumerable<NoteEntity> GetAllNotesByLabelName(long labelId, int userId);
    }
}
