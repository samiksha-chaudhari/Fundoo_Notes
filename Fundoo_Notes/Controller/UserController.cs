using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoo_Notes.Controller
{
    public class UserController:ControllerBase
    {
        private readonly IUserManager manager;
        private readonly ILogger<UserController> logger;

        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }
        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel userData)
        {
            try
            {
                string result = await this.manager.Register(userData);
                if (result.Equals("Registration Successfull"))
                {
                    logger.LogInformation("New user added successfully with Firstname:" + userData.FirstName);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("Exception thrown" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        //private IActionResult Ok<T>(ResponseModel<T> responseModel)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        [Route("api/Login")]
        public IActionResult LogIn([FromBody] LoginModel login)
        {
            try
            {
                string result = this.manager.LogIn(login);

                if (result.Equals("Login Successfull"))
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string firstName = database.StringGet("First Name");
                    string lastName = database.StringGet("Last Name");

                    RegisterModel data = new RegisterModel
                    {
                        FirstName=firstName,
                        LastName=lastName,
                        //ID=userId,
                        Email=login.Email
                    };
                    string tokenString = this.manager.GenerateToken(login.Email);
                    logger.LogInformation("Login Successfull");
                    return this.Ok(new { Status = true, Message = result, Data = data, Token = tokenString }) ;
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("Exception thrown" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel userData)
        {
            try
            {
                string result = await this.manager.ResetPassword(userData);
                if (result.Equals("Password Updated"))
                {
                    logger.LogInformation("Password Updated");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {

                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("Exception thrown" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/forgetpassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                string result =  this.manager.ForgotPassword(email);
                if (result.Equals("Mail is send"))
                {
                    logger.LogInformation("Mail is send");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {

                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("Exception thrown" + ex.Message);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}

