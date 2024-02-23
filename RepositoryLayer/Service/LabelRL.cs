using RepositoryLayer.Entitys;
using RepositoryLayer.Innterface;


namespace RepositoryLayer.Service
{
    public class LabelRL : ILabelRL
    {
        private readonly FundooNotesDBContext dbContext;
        public LabelRL(FundooNotesDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddLabelToNote(string label, long noteId, int userId)
        {
            NoteEntity note = dbContext.Notes.Where(x => x.NoteID == noteId && x.UserId == userId).FirstOrDefault();
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
        public bool RemoveLabelFromNote(long labelId, long noteId, int userId)
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
        public bool UpdateLabelForNote(long labelId, string newLabel, long noteId, int userId)
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

        public bool AddLabel(string label, int userId)
        {
            LabelEntity labelEntity = new LabelEntity
            {
                LabelName = label,
                UserId = userId
            };
            dbContext.Lables.Add(labelEntity);
            dbContext.SaveChanges();
            return true;
        }
        public bool RemoveLabel(long labelId, int userId)
        {
            LabelEntity labelEntity = dbContext.Lables.FirstOrDefault(x => x.UserId == userId && x.LabelID == labelId);
            if (labelEntity != null)
            {
                dbContext.Lables.Remove(labelEntity);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}