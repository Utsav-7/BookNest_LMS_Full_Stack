using LMS_Backend.LMS.Application.DTOs.Authentication;

namespace LMS_Backend.LMS.Application.Interfaces.Authentication
{
    public interface IAuthRepository
    {
       public Task<object> LoginAsync(LoginDTO userLogin);
       public Task<string> RegisterAsync(RegisterDTO register);
       public Task<bool> ResetPassword(ResetPwdDTO resetPwd);
       public Task<int> SendOtpToEmail(ForgotPwdDTO dto);
    }
}