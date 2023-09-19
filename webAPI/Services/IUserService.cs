using webAPI.Models;

namespace webAPI.Services
{
    public interface IUserService<L>
    {
        Task<UserManagerResponse> LoginUserAsync(L user);
    }
    
}
