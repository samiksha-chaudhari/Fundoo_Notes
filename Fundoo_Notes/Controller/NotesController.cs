using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoo_Notes.Controller
{
    public class NotesController : ControllerBase
    {
        private readonly INotesManager manager;

        public NotesController(INotesManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/addnotes")]
        public IActionResult AddNote([FromBody] NotesModel noteData)
        {
            try
            {
                string result = this.manager.AddNote(noteData);
                if (result.Equals("Add Successfull"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/deletenote")]
        public IActionResult DeleteNote(int noteId)
        {
            try
            {
                string result = this.manager.DeleteNote(noteId);
                if (result.Equals("Note is Deleted"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/updatenote")]
        public IActionResult UpdateNote(NotesModel noteData)
        {
            try
            {
                string result = this.manager.UpdateNote(noteData);
                if (result.Equals("Note Updated"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result});
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/pin")]
        public IActionResult Pin(int noteId)
        {
            try
            {
                bool result = this.manager.Pin(noteId);
                if (result)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Pinned" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note not Found" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/colour")]
        public IActionResult Colour(int noteId, string noteColor)
        {
            try
            {
                string result = this.manager.Colour(noteId, noteColor);
                if (result.Equals("Colour Changed"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/reminder")]
        public IActionResult SetReminder(int noteID, string reminder)
        {
            try
            {
                string result = this.manager.SetReminder(noteID, reminder);
                if (result.Equals("Reminder Set"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

    }
}
