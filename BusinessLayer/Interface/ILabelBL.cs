<<<<<<< HEAD
﻿using System;
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
=======
﻿namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        bool AddLabelToNote(string label, long noteId, int userId);
        bool RemoveLabelFromNote(long labelId, long noteId, int userId);
        bool UpdateLabelForNote(long labelId, string newLabel, long noteId, int userId);
        bool AddLabel(string label, int userId);
        bool RemoveLabel(long labelId, int userId);
>>>>>>> 896f895f42d09d1f10c9f51804d233948b59fa77
    }
}
