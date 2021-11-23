using Experimental.System.Messaging;
using FundooModel;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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

        //public string EncryptPassword(string password)
        //{
        //    try
        //    {
        //        byte[] EncryptPaas = new byte[password.Length];
        //        EncryptPaas = System.Text.Encoding.UTF8.GetBytes(password);
        //        string EncodedData = Convert.ToBase64String(EncryptPaas);
        //        return EncodedData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public string EncryptPassword(string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public IConfiguration Configuration { get; }
        public async Task<string> Register(RegisterModel userData)
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
                        await this.userContext.SaveChangesAsync();
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

        public string LogIn(LoginModel logIn)
        {
            try
            {               
                var validEmail = this.userContext.Users.Where(x => x.Email == logIn.Email).FirstOrDefault();
                if (validEmail != null)
                {
                    logIn.Password = EncryptPassword(logIn.Password);
                    var validPassword = this.userContext.Users.Where(x => x.Password == logIn.Password).FirstOrDefault();
                    if (validPassword == null)
                    {
                        return "Login Successfull";
                    }

                    return "Enter Correct Password ";
                }
                return "Email Incorrect";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<string> ResetPassword(ResetPasswordModel userData)
        {
            try
            {
                var validEmail = this.userContext.Users.Where(x => x.Email == userData.Email).FirstOrDefault();
                if (userData != null)
                {
                    validEmail.Password = EncryptPassword(userData.NewPassword);
                    this.userContext.Update(validEmail);
                    await this.userContext.SaveChangesAsync();
                    return "Password Updated";
                }

                return "Not Updated";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ForgotPassword(string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(this.Configuration["Credentials: Email"]);
                mail.To.Add(email);
                mail.Subject = "To Test Out Mail";
                SendMSMQ();
                mail.Body = ReceiveMSMQ();

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(this.Configuration["Credentials: Email"], this.Configuration["Credentials: Password"]);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return "Mail is send";

            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SendMSMQ()
        {
            MessageQueue messageQueue;
            if (MessageQueue.Exists(@".\Private$\Fundoo"))
            {
                messageQueue = new MessageQueue(@".\Private$\Fundoo");
            }
            else
            {
                messageQueue = MessageQueue.Create(@".\Private$\Fundoo");
            }
            string body = "This is for Testing SMTP mail from GMAIL";
            messageQueue.Label = "Mail Body";
            messageQueue.Send(body);
        }
        public string ReceiveMSMQ()
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\Fundoo");
            var receivemsg = messageQueue.Receive();
            return receivemsg.ToString();
        }
    }
}