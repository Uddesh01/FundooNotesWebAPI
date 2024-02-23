
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

﻿namespace RepositoryLayer.Innterface
{
    public interface ILabelRL
    {
        bool AddLabelToNote(string label, long noteId, int userId);
        bool RemoveLabelFromNote(long labelId, long noteId, int userId);
        bool UpdateLabelForNote(long labelId, string newLabel, long noteId, int userId);
        bool RemoveLabel(long labelId, int userId);
        bool AddLabel(string label, int userId);
    }
}
