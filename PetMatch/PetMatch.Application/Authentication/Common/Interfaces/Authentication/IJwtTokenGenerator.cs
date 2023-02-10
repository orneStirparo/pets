using PetMatch.Domain.Users;

namespace PetMatch.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}