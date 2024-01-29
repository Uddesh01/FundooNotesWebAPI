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
        public readonly ILabelRL iLabelRL;
        public IConfiguration configuration;
        public LabelBL(ILabelRL labelRL, IConfiguration configuration)
        {
            this.iLabelRL = labelRL;
            this.configuration = configuration;
        }
        public bool AddLabelToNote(string label, long noteId, int userId)
        {
            return iLabelRL.AddLabelToNote(label, noteId,userId);
        }

        bool ILabelBL.RemoveLabelFromNote(long labelId, long noteId, int userId)
        {
            return iLabelRL.RemoveLabelFromNote(labelId, noteId, userId);
        }

        bool ILabelBL.UpdateLabelForNote(long labelId, string newLabel, long noteId, int userId)
        {
            return iLabelRL.UpdateLabelForNote(labelId,newLabel,noteId,userId);
        }
    }
}
