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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
