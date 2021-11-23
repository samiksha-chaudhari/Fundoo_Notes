using FundooModel;

namespace FundooRepository.Interfac
{
    public interface INotesRepository
    {
        string AddNote(NotesModel noteData);
        string DeleteNote(int noteId);
    }
}