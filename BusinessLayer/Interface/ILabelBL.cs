using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        public bool AddLabel(long noteId, int userId, string label);
        public bool UpdateLabel(long noteId, int userId, string newLabel, long labelId);
        public bool RemoveLabel(long noteId,int userId,long labelId);
    }
}
