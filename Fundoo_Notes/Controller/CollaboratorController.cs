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
        private readonly CollaboratorManager manager;
        public CollaboratorController(CollaboratorManager manager)
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
    }
}
