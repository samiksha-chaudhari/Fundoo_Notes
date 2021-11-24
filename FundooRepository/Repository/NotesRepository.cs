using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interfac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;

        public readonly IConfiguration configuration;
        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        public string AddNote(NotesModel noteData)
        {
            try
            {
                var validUser = this.userContext.Users.Where(x => x.ID == noteData.ID).FirstOrDefault();
                if (validUser != null)
                {
                    if (noteData.Title != null || noteData.Description != null)
                    {
                        this.userContext.Notes.Add(noteData);
                        this.userContext.SaveChanges();
                        return "Add Successfull";
                    }

                    return "Unsuccessfull"; 
                }
                return "UserId not Present";
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
                var findNote = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (findNote != null)
                {
                    this.userContext.Notes.Remove(findNote);
                    this.userContext.SaveChanges();
                    return "Note is Deleted";
                }
                else
                {
                    return "Note is not Found";
                }                
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
                var findNote = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();

                if (findNote != null)
                {
                    findNote.Title = noteData.Title;
                    findNote.Description = noteData.Description;
                    this.userContext.SaveChanges();
                    return "Note Updated";
                }
                else 
                {
                    return "Note Not Updated";
                }
               
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
                var findNote = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (findNote != null)
                {
                    if(findNote.Pin==false)
                    {
                        findNote.Pin = true;
                        findNote.Archive = false;
                        this.userContext.SaveChanges();
                    }
                    else
                    {
                        findNote.Pin = false;
                        findNote.Archive = false;
                        this.userContext.SaveChanges();
                    }
                    return true;

                }
                else 
                {
                    return false;
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Colour(int noteId, string notecolor)
        {
            try
            {
                var findNote = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (findNote != null)
                {
                    findNote.Colour = notecolor;
                    this.userContext.SaveChanges();
                    return "Colour Changed";
                }
                else 
                {
                    return "Colour not Changed ";
                }
                
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
                var findNote = this.userContext.Notes.Where(x => x.NoteId == noteID).FirstOrDefault();
                if (findNote != null)
                {
                    findNote.Reminder = reminder;
                    this.userContext.SaveChanges();
                    return "Reminder Set";
                }
                else 
                {
                    return "noteID not Exist";
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
