using FundooManager.Interface;
using FundooManager.Manager;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoo_Notes.Controller
{
    public class CollaboratorController: ControllerBase
    {
        private readonly ICollaboratorManager manager;
        public CollaboratorController(ICollaboratorManager manager) ////construtor
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/addcollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel Data)
        {
            try
            {
                string result = this.manager.AddCollaborator(Data);
                if (result.Equals("Collaborator Added Successfull"))
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
        [Route("api/deletecollaborator")]
        public IActionResult DeleteCollaborator(int collaboratorID)
        {
            try
            {
                string result = this.manager.DeleteCollaborator(collaboratorID);
                if (result.Equals("collaborator is Deleted"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/getcollaborator")]
        public IActionResult GetCollaborator(int noteId)
        {
            try
            {
                var result = this.manager.GetCollaborator(noteId);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<CollaboratorModel>>() { Status = true, Message = "Get All Collaborator", Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Collaborator not Found" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
