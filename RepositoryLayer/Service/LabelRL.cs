using Microsoft.Extensions.Configuration;
using RepositoryLayer;
using RepositoryLayer.Entitys;
using RepositoryLayer.Innterface;
using System.Security.Cryptography.Xml;

<<<<<<< HEAD
namespace RepositoryLayer.Service
{
    public class LabelRL : ILabelRL
    {
        public readonly FundooNotesDBContext dbContext;
        public IConfiguration configuration;
        public LabelRL(FundooNotesDBContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }
        bool ILabelRL.AddLabel(long noteId, int userId, string label)
        {
            LabelEntity _label = new LabelEntity
            {
                LabelName = label,
                UserId = userId,
                NoteID = noteId
            };
            dbContext.Lables.Add(_label);
            dbContext.SaveChanges();
            return true;
        }

        bool ILabelRL.RemoveLabel(long noteId, int userId, long labelId)
        {
            LabelEntity lableEntity = dbContext.Lables.Where(x => x.LabelID == labelId && x.NoteID == noteId && x.UserId == userId).FirstOrDefault();
            if (lableEntity != null)
            {
                dbContext.Lables.Remove(lableEntity);
                dbContext.SaveChanges();
                return true;
            }
            else 
            {
                throw new InvalidOperationException("Label not found for the specified noteId and userId. Update failed.");
            }
        }

        bool ILabelRL.UpadateLabel(long noteId, int userId, string newLabel,long labelId)
        {
            LabelEntity labelEntity = dbContext.Lables.Where(x => x.LabelID==labelId &&  x.NoteID == noteId && x.UserId==userId).FirstOrDefault();
            if (labelEntity != null)
            {
                labelEntity.LabelName = newLabel;
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                throw new InvalidOperationException("Label not found for the specified noteId and userId. Update failed.");
            }
            
=======
public class LabelRL : ILabelRL
{
    private readonly FundooNotesDBContext dbContext;
    public LabelRL(FundooNotesDBContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public bool AddLabelToNote(string label, long noteId,int userId)
    {
        NoteEntity note = dbContext.Notes.Where(x => x.NoteID==noteId && x.UserId==userId).FirstOrDefault();      
        if (note != null)
        {
            LabelEntity labelEntity = dbContext.Lables.FirstOrDefault(x => x.LabelName == label);

            if (labelEntity == null)
            {
                labelEntity = new LabelEntity
                {
                    LabelName = label,
                    UserId = userId
                };

                dbContext.Lables.Add(labelEntity);
                dbContext.SaveChanges();
            }

            NoteLabelEntity noteLabel = new NoteLabelEntity
            {
                NoteID = noteId,
                LabelID = labelEntity.LabelID
            };

            dbContext.NoteLabels.Add(noteLabel);
            dbContext.SaveChanges();

            return true;
        }

        return false;
    }
    public bool RemoveLabelFromNote(long labelId, long noteId,int userId)
    {
        NoteEntity note = dbContext.Notes.Where(x => x.NoteID == noteId && x.UserId == userId).FirstOrDefault();

        if (note != null)
        {
            LabelEntity labelEntity = dbContext.Lables.FirstOrDefault(x => x.LabelID == labelId);

            if (labelEntity != null)
            {
                NoteLabelEntity noteLabel = dbContext.NoteLabels.FirstOrDefault(x => x.NoteID == noteId && x.LabelID == labelEntity.LabelID);

                if (noteLabel != null)
                {
                    dbContext.NoteLabels.Remove(noteLabel);
                    dbContext.SaveChanges();
                    return true;
                }
            }
        }

        return false;
    }
    public bool UpdateLabelForNote(long labelId, string newLabel, long noteId,int userId)
    {
        NoteEntity note = dbContext.Notes.Where(x => x.NoteID == noteId && x.UserId == userId).FirstOrDefault();
        if (note != null)
        {
            LabelEntity oldLabelEntity = dbContext.Lables.FirstOrDefault(x => x.LabelID == labelId);

            if (oldLabelEntity != null)
            {
                NoteLabelEntity noteLabel = dbContext.NoteLabels.FirstOrDefault(x => x.NoteID == noteId && x.LabelID == oldLabelEntity.LabelID);

                if (noteLabel != null)
                {
                    dbContext.NoteLabels.Remove(noteLabel);
                    LabelEntity newLabelEntity = dbContext.Lables.FirstOrDefault(x => x.LabelName == newLabel);

                    if (newLabelEntity == null)
                    {
                        newLabelEntity = new LabelEntity
                        {
                            LabelName = newLabel,
                            UserId = userId
                        };
                        dbContext.Lables.Add(newLabelEntity);
                        dbContext.SaveChanges();
                    }

                    NoteLabelEntity newNoteLabel = new NoteLabelEntity
                    {
                        NoteID = noteId,
                        LabelID = newLabelEntity.LabelID
                    };

                    dbContext.NoteLabels.Add(newNoteLabel);
                    dbContext.SaveChanges();

                    return true;
                }
            }
        }
        return false;
    }

    public bool AddLabel(string label,int userId)
    {
        LabelEntity labelEntity = new LabelEntity
        {
            LabelName=label,
            UserId=userId
        };
        dbContext.Lables.Add(labelEntity);
        dbContext.SaveChanges();
        return true;
    }
    public bool RemoveLabel(long labelId,int userId)
    {
        LabelEntity labelEntity = dbContext.Lables.FirstOrDefault(x => x.UserId==userId && x.LabelID==labelId);
        if (labelEntity != null) 
        {
            dbContext.Lables.Remove(labelEntity);
            dbContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
>>>>>>> 896f895f42d09d1f10c9f51804d233948b59fa77
        }
    }
}
