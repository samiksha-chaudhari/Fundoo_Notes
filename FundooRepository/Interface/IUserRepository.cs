using FundooModel;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Repository
{
    public interface IUserRepository
    {
        IConfiguration Configuration { get; }

        string Register(RegisterModel userData);
        string LogIn(LoginModel login);
        string ResetPassword(ResetPasswordModel userData);//it is true if password updated

    }
}