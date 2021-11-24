using FundooManager.Manager;
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
    }
}
