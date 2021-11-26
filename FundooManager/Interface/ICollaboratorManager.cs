using FundooModel;
using System.Collections.Generic;

namespace FundooManager.Interface
{
    public interface ICollaboratorManager
    {
        string AddCollaborator(CollaboratorModel Data);
        string DeleteCollaborator(int collaboratorID);
        IEnumerable<CollaboratorModel> GetCollaborator(int noteId);
    }
}