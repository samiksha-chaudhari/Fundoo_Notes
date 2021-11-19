using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundoo_Notes.Controller
{
    public class UserController:ControllerBase
    {
        private readonly IUserManager manager;

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody] RegisterModel userData)
        {
            try
            {
                string result = this.manager.Register(userData);

                if (result.Equals("Registration Successfull"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
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

                if (result.Equals("Login Successfull "))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/resetpassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel userData)
        {
            try
            {
                string result = this.manager.ResetPassword(userData);
                if (result.Equals("Password Updated"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
                else
                {

                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}

