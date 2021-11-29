using FundooModel;
using System.Collections.Generic;

namespace FundooManager.Interface
{
    public interface ILabelManager
    {
        string AddLabel(LabelModel labelData);
        string DeleteLabel(int labelId);
        string DeleteLabelUID(int userId);
        IEnumerable<LabelModel> GetLabel(int noteId);
        IEnumerable<LabelModel> GetLabelUser(int userId);
        string EditLabel(LabelModel labelData);
    }
}