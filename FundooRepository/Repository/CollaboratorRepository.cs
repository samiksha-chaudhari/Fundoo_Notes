using FundooRepository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Repository
{
    public class CollaboratorRepository
    {
        private readonly UserContext userContext;
        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
       
    }
}
