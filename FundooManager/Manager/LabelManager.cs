using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interfac;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepository repository;
        public LabelManager(ILabelRepository repository)
        {
            this.repository = repository;
        }
        public string AddLabel(LabelModel labelData)
        {
            try
            {
                return this.repository.AddLabel(labelData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteLabel(int labelId)
        {
            try
            {
                return this.repository.DeleteLabel(labelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteLabelUID(int userId)
        {
            try
            {
                return this.repository.DeleteLabelUID(userId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<LabelModel> GetLabel(int noteId)
        {
            try
            {
                return this.repository.GetLabel(noteId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }

        public IEnumerable<LabelModel> GetLabelUser(int userId)
        {
            try 
            {
                return this.repository.GetLabelUser(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public string EditLabel(LabelModel labelData)
        {
            try
            {
                return this.repository.EditLabel(labelData);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
