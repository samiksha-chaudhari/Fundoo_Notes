﻿using FundooModel;

namespace FundooManager.Interface
{
    public interface INotesManager
    {
        string AddNote(NotesModel noteData);
        string DeleteNote(int noteId);
    }
}