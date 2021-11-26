﻿using FundooModel;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FundooRepository.Interfac
{
    public interface IUserRepository
    {
        IConfiguration Configuration { get; }

        Task<string> Register(RegisterModel userData);
        string LogIn(LoginModel login);
        Task<string> ResetPassword(ResetPasswordModel userData);
        string ForgotPassword(string email);
        string GenerateToken(string email);

    }
}