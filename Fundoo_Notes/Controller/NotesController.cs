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
    }
}
