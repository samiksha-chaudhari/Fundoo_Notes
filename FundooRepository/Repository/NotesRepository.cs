using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Repository
{
    public class NotesRepository
    {       
        private readonly UserContext userContext;

        private readonly IConfiguration configuration;
        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

    }
}
