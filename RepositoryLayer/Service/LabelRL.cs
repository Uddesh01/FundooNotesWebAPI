using Microsoft.Extensions.Configuration;
using RepositoryLayer;
using RepositoryLayer.Entitys;
using RepositoryLayer.Innterface;
using System.Security.Cryptography.Xml;

public class LabelRL : ILabelRL
{
    private readonly FundooNotesDBContext dbContext;
    private readonly IConfiguration configuration;

    public LabelRL(FundooNotesDBContext dbContext, IConfiguration configuration)
    {
        this.dbContext = dbContext;
        this.configuration = configuration;
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
                    NoteID = noteId
                };

                dbContext.Lables.Add(labelEntity);
                dbContext.SaveChanges();
            }

            if (dbContext.NoteLabels.Any(x => x.NoteID == noteId && x.LabelID == labelEntity.LabelID))
            {
                return true;
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
                            NoteID = noteId
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

}
