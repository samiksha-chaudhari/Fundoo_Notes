using FundooModel;
using System.Collections.Generic;

namespace FundooRepository.Interfac
{
    public interface ICollaboratorRepository
    {
        string AddCollaborator(CollaboratorModel Data);
        string DeleteCollaborator(int collaboratorID);
        IEnumerable<CollaboratorModel> GetCollaborator(int noteId);
    }
}