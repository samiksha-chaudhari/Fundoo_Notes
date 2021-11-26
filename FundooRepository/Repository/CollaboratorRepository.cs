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

        public string DeleteCollaborator(int collaboratorID)
        {
            try
            {
                var collaborator = this.userContext.Collaborator.Where(x => x.CollaboratorId == collaboratorID).FirstOrDefault();
                if (collaborator != null)
                {
                    this.userContext.Remove(collaborator);
                    this.userContext.SaveChanges();
                    return "collaborator is Deleted";
                }
                return "collaboratoe is not Deleted";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CollaboratorModel> GetCollaborator(int noteId)
        {
            try
            {
                IEnumerable<CollaboratorModel> Collaborator = this.userContext.Collaborator.Where(x=> x.NoteId == noteId).ToList();
                if (Collaborator != null)
                {
                    return Collaborator;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
