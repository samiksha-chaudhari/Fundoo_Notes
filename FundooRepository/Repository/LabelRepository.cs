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
    public class LabelRepository : ILabelRepository
    {
        private readonly UserContext userContext;

        public readonly IConfiguration configuration;
        public LabelRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        public string AddLabel(LabelModel labelData)//passing label data 
        {
            try
            {
                if (labelData != null)
                {
                    this.userContext.Add(labelData);
                    this.userContext.SaveChanges();
                    return "Label Add Successfull";
                }
                else
                {
                    return "Unsuccessfull";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteLabel(int labelId)//passing note Id
        {
            try
            {
                var findLabel = this.userContext.label.Where(x => x.LabelId == labelId).FirstOrDefault();
                if (findLabel != null)
                {
                    if (findLabel != null)
                    {
                        this.userContext.label.Remove(findLabel);
                        this.userContext.SaveChanges();
                        return "Label is Deleted";
                    }
                    else
                    {
                        return "Label is not Found";
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteLabelUID(int userId)//passing User Id
        {
            try
            {
                var findLabel = this.userContext.label.Where(x => x.ID == userId).FirstOrDefault();
                if (findLabel != null)
                {
                    if (findLabel != null)
                    {
                        this.userContext.label.Remove(findLabel);
                        this.userContext.SaveChanges();
                        return "Label is Deleted";
                    }
                    else
                    {
                        return "Label is not Found";
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<LabelModel> GetLabel(int noteId)//give total labels for noteId
        {
            try
            {
                IEnumerable<LabelModel> labels = this.userContext.label.Where(x => x.NoteId == noteId).ToList();
                if (labels != null)
                {
                    return labels;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<LabelModel> GetLabelUser(int userId)//give total labels for userId
        {
            try
            {
                IEnumerable<LabelModel> labels = this.userContext.label.Where(x => x.ID == userId).ToList();
                if (labels != null)
                {
                    return labels;
                }
                return null;
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
                var findLabel = this.userContext.label.Find(labelData.LabelId);
                if (findLabel != null)
                {
                    findLabel.ID = labelData.ID;
                    findLabel.Label = labelData.Label;
                    this.userContext.SaveChanges();
                    return "Label Updated";
                }

                return "Not Found";
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
