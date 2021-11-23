﻿using FundooModel;
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

        public string UpdateNote(NotesModel noteData)
        {
            try
            {
                var findNote = this.userContext.Notes.Find(noteData.NoteId);

                if (findNote != null)
                {
                    findNote.Title = noteData.Title;
                    findNote.Description = noteData.Description;
                    this.userContext.SaveChanges();
                    return "Note Updated";
                }

                return "Note Not Updated";
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
                var findNote = this.userContext.Notes.Find(noteId);
                if (findNote != null)
                {
                    findNote.Pin = findNote.Pin;
                    findNote.Archive = false;
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
