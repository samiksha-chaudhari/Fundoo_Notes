using FundooModel;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;
        public UserRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        public static string EncryptPassword(string password)
        {
            try
            {
                byte[] EncryptPaas = new byte[password.Length];
                EncryptPaas = System.Text.Encoding.UTF8.GetBytes(password);
                string EncodedData = Convert.ToBase64String(EncryptPaas);
                return EncodedData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IConfiguration Configuration { get; }
        public string Register(RegisterModel userData)
        {
            try
            {
                var validEmail = this.userContext.Users.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (validEmail == null)
                {
                    if (userData != null)
                    {
                        // Encrypting the password
                        userData.Password = EncryptPassword(userData.Password);
                        // Add the data to the database
                        this.userContext.Users.Add(userData);
                        // Save the change in database
                        this.userContext.SaveChanges();
                        return "Registration Successfull";
                    }
                    return "Registration UnSuccessfull";
                }
                return "Email Id Already Exists";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string LogIn(LoginModel logIn)//here class is used as datatype and its parameter
        {
            try
            {
                var validEmail = this.userContext.Users.Where(x => x.Email == logIn.Email).FirstOrDefault();
                var validPassword = this.userContext.Users.Where(x => x.Password == logIn.Password).FirstOrDefault();
                if (validEmail == null && validPassword == null)
                {
                    return "Login UnSuccessfull";
                }
                else
                {
                    return "Login Successfull ";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
