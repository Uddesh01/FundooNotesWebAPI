using BusinessLayer.Interface;
using RepositoryLayer.Innterface;

namespace BusinessLayer.Sevice
{
    public class LabelBL : ILabelBL
    {
        public readonly ILabelRL ilabelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.ilabelRL = labelRL;
        }

        bool ILabelBL.AddLabel(long noteId, int userId, string label)
        {
           return ilabelRL.AddLabel(noteId, userId, label);
        }

        bool ILabelBL.UpdateLabel(long noteId, int userId, string newLabel, long labelId)
        {
            return ilabelRL.UpadateLabel(noteId, userId, newLabel,labelId);
        }
        public bool RemoveLabel(long noteId, int userId, long labelId)
        {
            return ilabelRL.RemoveLabel(noteId,userId,labelId);
        }
    }

}
