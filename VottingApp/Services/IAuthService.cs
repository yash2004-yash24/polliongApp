using VottingApp.Models;
using VottingApp.Models.DTOs;

namespace VottingApp.Services
{
    public interface IAuthService
    {
        Task<Users> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
        Task<int> GetUserByUserEmail(string userid);
    }
}