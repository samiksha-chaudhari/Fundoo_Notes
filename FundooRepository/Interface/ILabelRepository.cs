﻿using FundooModel;
using System.Collections.Generic;

namespace FundooRepository.Interfac
{
    public interface ILabelRepository
    {
        string AddLabel(LabelModel labelData);
        string DeleteLabel(int labelId);
        IEnumerable<LabelModel> GetLabel(int noteId);
        IEnumerable<LabelModel> GetLabelUser(int userId);
    }
}