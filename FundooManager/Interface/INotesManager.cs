using FundooModel;

namespace FundooManager.Interface
{
    public interface INotesManager
    {
        string AddNote(NotesModel noteData);
        string DeleteNote(int noteId);
        string UpdateNote(NotesModel noteData);
        bool Pin(int noteId);
        string Colour(int noteId, string noteColor);
        string SetReminder(int noteID, string reminder);
    }
}