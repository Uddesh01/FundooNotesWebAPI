namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        bool AddLabelToNote(string label, long noteId, int userId);
        bool RemoveLabelFromNote(long labelId, long noteId, int userId);
        bool UpdateLabelForNote(long labelId, string newLabel, long noteId, int userId);
        bool AddLabel(string label, int userId);
        bool RemoveLabel(long labelId, int userId);
    }
}