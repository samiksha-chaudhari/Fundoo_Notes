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
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly UserContext userContext;
        public readonly IConfiguration configuration;
        public CollaboratorRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public string AddCollaborator(CollaboratorModel Data)
        {
            try
            {
                if (Data != null)
                {
                    this.userContext.Collaborator.Add(Data);
                    this.userContext.SaveChanges();
                    return "Collaborator Added Successfull";
                }

                return "Collaborator Not Added";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
