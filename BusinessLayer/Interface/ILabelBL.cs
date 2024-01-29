using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        bool AddLabelToNote(string label,long noteId, int userId);
        bool RemoveLabelFromNote(long labelId, long noteId, int userId);
        bool UpdateLabelForNote(long labelId, string newLabel, long noteId, int userId);
    }
}
