using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interfac;
using Microsoft.AspNetCore.Http;
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

        public string AddNote(NotesModel noteData)//passing note data title,desciption etc
        {
            try
            {
                if (noteData != null)
                {
                    this.userContext.Add(noteData);
                    this.userContext.SaveChanges();
                    return "Add Successfull";
                }
                else 
                {
                    return "Unsuccessfull";
                }              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteNote(int noteId)//passing note Id
        {
            try
            {
                var findNote = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (findNote != null)
                {
                    if (findNote.Trash != true)
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
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateNote(NotesModel noteData)//passing note data title,desciption etc
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

        public bool Pin(int noteId)//passing note Id
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

        public string Colour(int noteId, string notecolor)//passing note Id and colour
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

        public string SetReminder(int noteID, string reminder)//passing note Id and reminder string
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

        public bool Archive(int noteId)//passing note Id
        {
            try
            {
                var findNote = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (findNote != null)
                {
                    if (findNote.Archive == false)
                    {
                        findNote.Archive = true;
                        findNote.Pin = false;
                        this.userContext.SaveChanges();
                    }
                    else
                    {
                        findNote.Archive = false;
                        findNote.Pin = false;
                        this.userContext.SaveChanges();
                    }
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Trash(int noteId)//passing note Id
        {
            try
            {
                var findNote = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (findNote != null)
                {
                    if (findNote.Trash == false)
                    {
                        findNote.Trash = true;
                        findNote.Archive = false;
                        findNote.Pin = false;
                        findNote.Reminder = null;
                        this.userContext.SaveChanges();
                    }
                    else
                    {
                        findNote.Trash = false;
                        this.userContext.SaveChanges();
                    }
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NotesModel> GetNote(int Id)//passing user ID 
        {
            IEnumerable<NotesModel> notes = this.userContext.Notes.Where(x => x.ID == Id && x.Archive == false && x.Trash == false).ToList();
            try
            {
                if (notes != null)
                {
                    return notes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public List<string> GetNote(int Id)
        //{
        //    try
        //    {
        //        List<string> notesList = new List<string>();
        //        if (Id != 0)
        //        {
        //            IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.ID == Id select x;
        //            foreach (var note in notes)
        //            {
        //                 string result = "NoteID = " + note.NoteId + " " + "Title = " + note.Title + " " + "Description = " + note.Description + " " + "Reminder = " + note.Reminder + " " + "Colour = "+ note.Colour + " " + "Pin = " + note.Pin + " " + "Archive = " + note.Archive + " " + "Trash = " + note.Trash;
        //                notesList.Add(result);
        //            }
        //            return notesList;
        //        }
        //        else
        //        {
        //            return null;
        //        } 
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public IEnumerable<NotesModel> GetArchive(int Id)//passing user ID 
        {
            IEnumerable<NotesModel> notes = this.userContext.Notes.Where(x => x.ID == Id && x.Archive == true).ToList();
            try
            {
                if (notes != null)
                {
                    return notes;
                }
                else
                {
                    return null;
                }
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
                var findNote = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (findNote != null)
                {
                    var cloudinary = new Cloudinary(
                                                new Account(
                                                "samiksha-chaudhari",
                                                "664494558437555",
                                                "K8gkv7cmMS5iJIML_EKfdn0CeKI"));

                    var uploadImage = new ImageUploadParams()
                    {
                        File = new FileDescription(path.FileName, path.OpenReadStream())
                    };
                    var uploadResult = cloudinary.Upload(uploadImage);
                    var uploadPath = uploadResult.Url;
                    findNote.Image = uploadPath.ToString();
                    this.userContext.SaveChanges();
                    return "Image Uploaded";
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
