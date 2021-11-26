using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interfac;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly ICollaboratorRepository repository;
        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.repository = repository;
        }
        public string AddCollaborator(CollaboratorModel Data)
        {
            try
            {
                return this.repository.AddCollaborator(Data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string DeleteCollaborator(int collaboratorID)
        {
            try
            {
                return this.repository.DeleteCollaborator(collaboratorID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<CollaboratorModel> GetCollaborator(int noteId)
        {
            try
            {
                return this.repository.GetCollaborator(noteId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
