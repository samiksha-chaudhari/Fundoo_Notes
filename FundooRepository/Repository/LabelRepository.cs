using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interfac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Repository
{
    class LabelRepository : ILabelRepository
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
                    return "Add Successfull";
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
    }
}
