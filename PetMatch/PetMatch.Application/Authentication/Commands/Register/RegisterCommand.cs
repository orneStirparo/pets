using PetMatch.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace PetMatch.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ConfirmPassword) : IRequest<ErrorOr<AuthenticationResult>>;