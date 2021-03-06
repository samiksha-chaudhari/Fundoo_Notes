using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interfac;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository repository;
        public NotesManager(INotesRepository repository)
        {
            this.repository = repository;
        }
        public string AddNote(NotesModel noteData)
        {
            try
            {
                return this.repository.AddNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteNote(int noteId)
        {
            try
            {
                return this.repository.DeleteNote(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateNote(NotesModel noteData)
        {
            try
            {
                return this.repository.UpdateNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 

        public bool Pin(int noteId)
        {
            try
            {
                return this.repository.Pin(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Colour(int noteId, string noteColor)
        {
            try
            {
                return this.repository.Colour(noteId, noteColor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string SetReminder(int noteID, string reminder)
        {
            try
            {
                return this.repository.SetReminder(noteID, reminder);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Archive(int noteId)
        {
            try
            {
                return this.repository.Archive(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Trash(int noteId)
        {
            try
            {
                return this.repository.Trash(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NotesModel> GetNote(int Id)
        {
            try
            {
                return this.repository.GetNote(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NotesModel> GetArchive(int Id)
        {
            try
            {
                return this.repository.GetArchive(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddImage(int noteId, IFormFile path)
        {
            try
            {
                return this.repository.AddImage(noteId, path);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
