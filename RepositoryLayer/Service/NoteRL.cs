using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entitys;
using RepositoryLayer.Innterface;

namespace RepositoryLayer.Service
{
    public class NoteRL : INoteRL
    {
        public readonly FundooNotesDBContext dbContext;
        public IConfiguration configuration;
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
        public bool DeleteNote(long noteId, int _userId)
        {
            NoteEntity noteEntity = dbContext.Notes.Where(x => x.NoteID == noteId && x.UserId == _userId).FirstOrDefault();
            dbContext.Notes.Remove(noteEntity);
            dbContext.SaveChanges();
            return true;
        }

        bool INoteRL.Archive_UnArchive(int _userId, long noteId)
        {
            NoteEntity noteEntity = dbContext.Notes.Where(x => x.NoteID == noteId && x.UserId == _userId).FirstOrDefault();
            if (noteEntity != null)
            {
                if (noteEntity.Archive == true)
                {
                    noteEntity.Archive = false;
                }
                else
                {
                    noteEntity.Archive = true;
                }
            }
            else
            {
                throw new Exception("User or note not found!!");
            }
            dbContext.SaveChanges();
            return true;
        }

        NoteEntity INoteRL.EditNote(EditNoteModel editNote, int _userId, long noteId)
        {
            NoteEntity noteEntity = dbContext.Notes.Where(x => x.NoteID == noteId && x.UserId == _userId).FirstOrDefault();
            noteEntity.Title = editNote.Titel;
            noteEntity.Description = editNote.Discription;
            noteEntity.Edited = DateTime.UtcNow;
            dbContext.SaveChanges();
            return noteEntity;
        }

        bool INoteRL.Pin_Unpin(int _userId, long noteId)
        {
            NoteEntity noteEntity = dbContext.Notes.Where(x => x.NoteID == noteId && x.UserId == _userId).FirstOrDefault();
            if (noteEntity != null)
            {
                if (noteEntity.Pin == true)
                {
                    noteEntity.Pin = false;
                }
                else
                {
                    noteEntity.Pin = true;
                }
            }
            else
            {
                throw new Exception("User or note not found!!");
            }
            dbContext.SaveChanges();
            return true;
        }

        bool INoteRL.Trash_UnTrash(int _userId, long noteId)
        {
            NoteEntity noteEntity = dbContext.Notes.Where(x => x.NoteID == noteId && x.UserId == _userId).FirstOrDefault();
            if (noteEntity != null)
            {
                if (noteEntity.Trash == true)
                {
                    noteEntity.Trash = false;
                }
                else
                {
                    noteEntity.Trash = true;
                }
            }
            else
            {
                throw new Exception("User or note not found!!");
            }
            dbContext.SaveChanges();
            return true;
        }

        public bool ChangeColor(int _userId, long noteId, string color)
        {
            NoteEntity noteEntity = dbContext.Notes.Where(x => x.NoteID == noteId && x.UserId == _userId).FirstOrDefault();
            if (noteEntity != null)
            {
                noteEntity.Color = color;
            }
            else
            {
                throw new Exception("User or note not found!!");
            }
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<NoteEntity> GetAllNotes(int _userId)
        {
            IEnumerable<NoteEntity> allNotes = dbContext.Notes.Where(x => x.UserId == _userId);
            if (allNotes != null)
            {
                return allNotes;
            }
            else
            {
                throw new Exception("User or notes are not found!!");
            }

        }

        public IEnumerable<NoteEntity> GetAllNotesByLabelName(long labelId, int userId)
        {
            var allNotes = from nl in dbContext.NoteLabels
                           join n in dbContext.Notes on nl.NoteID equals n.NoteID
                           where nl.LabelID == labelId && n.UserId == userId
                           select n;
            return allNotes;
        }
    }
}
