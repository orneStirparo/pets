using PetMatch.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace PetMatch.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;