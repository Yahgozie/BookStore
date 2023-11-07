using BookStore.AuthAPI.Models;

namespace BookStore.AuthAPI.Repository.IRepository
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
