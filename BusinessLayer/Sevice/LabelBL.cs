using BusinessLayer.Interface;
<<<<<<< HEAD
using RepositoryLayer.Innterface;
=======
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Innterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 896f895f42d09d1f10c9f51804d233948b59fa77

namespace BusinessLayer.Sevice
{
    public class LabelBL : ILabelBL
    {
<<<<<<< HEAD
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

=======
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
>>>>>>> 896f895f42d09d1f10c9f51804d233948b59fa77
}
