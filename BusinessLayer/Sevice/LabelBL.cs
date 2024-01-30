using BusinessLayer.Interface;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Innterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Sevice
{
    public class LabelBL : ILabelBL
    {
        private readonly ILabelRL iLabelRL;
        public LabelBL(ILabelRL labelRL)
        {
            iLabelRL = labelRL;
        }
        public bool AddLabelToNote(string label, long noteId, int userId)
        {
            return iLabelRL.AddLabelToNote(label, noteId,userId);
        }

       public bool RemoveLabelFromNote(long labelId, long noteId, int userId)
        {
            return iLabelRL.RemoveLabelFromNote(labelId, noteId, userId);
        }

        public bool UpdateLabelForNote(long labelId, string newLabel, long noteId, int userId)
        {
            return iLabelRL.UpdateLabelForNote(labelId,newLabel,noteId,userId);
        }

        public bool RemoveLabel(long labelId, int userId)
        {
            return iLabelRL.RemoveLabel(labelId, userId);
        }
        public bool AddLabel(string label, int userId)
        {
            return iLabelRL.AddLabel(label, userId);
        }
    }
}
