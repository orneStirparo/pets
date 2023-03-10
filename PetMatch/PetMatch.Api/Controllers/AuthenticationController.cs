using Microsoft.AspNetCore.Mvc;
using PetMatch.Contracts.Authentication;
using PetMatch.Domain.Common.Errors;
using MediatR;
using PetMatch.Application.Authentication.Commands.Register;
using PetMatch.Application.Authentication.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using PetMatch.Application.Authentication.Commands.Login;

namespace PetMatch.Api.Controllers;

[AllowAnonymous]
[Route("authentication")]
public class AuthenticationController : ApiController
{
    private readonly RegisterCommandValidator _validator;
    private readonly LoginCommandValidator _loginValidator;
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper, RegisterCommandValidator validator, LoginCommandValidator loginValidator)
    {
        _loginValidator = loginValidator;
        _validator = validator;
        _mediator = mediator;
        _mapper = mapper;
    }

    [Route("register")]
    public async Task<IActionResult> Register(RegisterCommand request)
    {
        var result = _validator.Validate(request);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
            return BadRequest(errors);
        }
        var response = new HttpResponseMessage();
        var command = _mapper.Map<RegisterCommand>(request);
        var authenticationResult = await _mediator.Send(command);

        return authenticationResult.Match(
            authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
            errors => Problem(errors));
    }

    [Route("login")]
    public async Task<IActionResult> Login(LoginCommand request)
    {
        var result = _loginValidator.Validate(request);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
            return BadRequest(errors);
        }
        var query = _mapper.Map<LoginQuery>(request);
        var authenticationResult = await _mediator.Send(query);

        if (authenticationResult.IsError && authenticationResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authenticationResult.FirstError.Description);
        }

        return authenticationResult.Match(
            authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
            errors => Problem(errors));
    }
}