using System.Threading.Tasks;
using WareHouse.Application.Auth.Models;

namespace WareHouse.Application.Auth
{
    public interface IAuthService
    {
        Task<SignInResultDto> SignInAsync(SignInDto signInDto);
        Task<SignUpResultDto> SignUpAsync(SignUpDto signUpDto);
    }
}
