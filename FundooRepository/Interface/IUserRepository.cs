using FundooModel;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public interface IUserRepository
    {
        IConfiguration Configuration { get; }

        string Register(RegisterModel userData);
        string LogIn(LoginModel login);
        string ResetPassword(ResetPasswordModel userData);
        string ForgotPassword(string email);

    }
}