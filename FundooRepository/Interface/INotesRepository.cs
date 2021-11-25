using FundooModel;
using System.Collections.Generic;

namespace FundooRepository.Interfac
{
    public interface INotesRepository
    {
        string AddNote(NotesModel noteData);
        string DeleteNote(int noteId);
        string UpdateNote(NotesModel noteData);
        bool Pin(int noteId);
        string Colour(int noteId, string noteColor);
        string SetReminder(int noteID, string reminder);
        bool Archive(int noteId);
        bool Trash(int noteId);
        List<string> GetNote(int Id);
    }
}