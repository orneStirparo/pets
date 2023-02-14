using PetMatch.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace PetMatch.Application.Authentication.Commands.Login;

public record LoginCommand(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;