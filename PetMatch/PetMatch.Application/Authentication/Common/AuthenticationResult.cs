using PetMatch.Domain.Users;

namespace PetMatch.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);