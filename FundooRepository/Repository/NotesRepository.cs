using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interfac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;

        private readonly IConfiguration configuration;
        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        public string AddNote(NotesModel noteData)
        {
            try
            {
                if (noteData.Title != null || noteData.Description != null)
                {
                    this.userContext.Notes.Add(noteData);
                    this.userContext.SaveChanges();
                    return "Add Successfull";
                }

                return "Unsuccessfull";
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
                var findNote = this.userContext.Notes.Find(noteId);
                if (findNote != null)
                {
                    this.userContext.Notes.Remove(findNote);
                    this.userContext.SaveChanges();
                    return "Note is Deleted";
                }

                return "Note is not Found";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
