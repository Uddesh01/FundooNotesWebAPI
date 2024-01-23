using CommonLayer.Model;
using RepositoryLayer.Entitys;
using RepositoryLayer.Innterface;

namespace RepositoryLayer.Service
{
    public class NoteRL : INoteRL
    {
        public readonly FundooNotesDBContext dbContext;
        public NoteRL(FundooNotesDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public NoteEntity AddNote(AddNoteModel newNote, int _userId)
        {
            var noteEntity = new NoteEntity
            {
                Title = newNote.Title,
                Description = newNote.Description,
                Reminder = newNote.Reminder,
                Color = newNote.Color,
                Image = newNote.Image,
                Archive = newNote.Archive,
                Pin = newNote.Pin,
                Trash = newNote.Trash,
                UserId = _userId,
                Created = DateTime.UtcNow,
                Edited = DateTime.UtcNow
            };

            dbContext.Notes.Add(noteEntity);
            dbContext.SaveChanges();
            return noteEntity;
        }
        public bool DeleteNote(DeleteNoteModel deleteNote)
        {
            NoteEntity noteEntity = dbContext.Notes.Where(x => x.NoteID == deleteNote.Id).FirstOrDefault();
            dbContext.Notes.Remove(noteEntity);
            dbContext.SaveChanges();
            return true;
        }
        NoteEntity INoteRL.EditNote(EditNoteModel newNote, int _userId)
        {
            NoteEntity noteEntity = dbContext.Notes.Where(x => x.NoteID == newNote.NoteID && x.UserId == _userId).FirstOrDefault();
            noteEntity.Title = newNote.Titel;
            noteEntity.Description = newNote.Discription;
            dbContext.SaveChanges();
            return noteEntity;
        }
    }
}
