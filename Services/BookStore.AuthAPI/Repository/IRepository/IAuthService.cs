using BookStore.AuthAPI.Models.Dto;

namespace BookStore.AuthAPI.Repository.IRepository
{
    public interface IAuthService
    {
        Task<string> Register(RegisterationRequestDto registerationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        //For assigning roles based on email and role name
        Task<bool> AssignRole(string email, string rolename);
    }
}
