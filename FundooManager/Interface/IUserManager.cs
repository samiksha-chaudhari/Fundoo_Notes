using FundooModel;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
    public interface IUserManager
    {
        string Register(RegisterModel userData);
        string LogIn(LoginModel login);
        string ResetPassword(ResetPasswordModel userData);
        string ForgotPassword(string email);
    }
}