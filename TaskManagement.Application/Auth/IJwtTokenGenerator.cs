using TaskManagement.Domain.User;

namespace TaskManagement.Application.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(int userId, string username, List<Role> roles);
    }
}
