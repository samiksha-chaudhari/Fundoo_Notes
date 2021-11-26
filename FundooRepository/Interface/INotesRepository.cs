using FundooModel;
using Microsoft.AspNetCore.Http;
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
        IEnumerable<NotesModel> GetNote(int Id);
        //List<string> GetNote(int Id);
        public IEnumerable<NotesModel> GetArchive(int Id);
        string AddImage(int noteId, IFormFile path);

    }
}