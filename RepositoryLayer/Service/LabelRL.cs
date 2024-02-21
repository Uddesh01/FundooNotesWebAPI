using Microsoft.Extensions.Configuration;
using RepositoryLayer;
using RepositoryLayer.Entitys;
using RepositoryLayer.Innterface;
using System.Security.Cryptography.Xml;

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
            
        }
    }
}
