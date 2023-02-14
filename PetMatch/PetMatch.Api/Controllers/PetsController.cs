using PetMatch.Application.Commands.Pets;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetMatch.Application.Common.Interfaces.Persistance;

namespace PetMatch.Api.Controllers;

[Route("pets")]
public class PetsController : ApiController
{
    private readonly IMapper _mapper;

    private readonly PetCommandValidator _validator;

    private readonly IPetRepository _petRepository;
    private readonly ISender _mediator;

    public PetsController(IMapper mapper, ISender mediator, IPetRepository petRepository, PetCommandValidator validator)
    {
        _validator = validator;
        _petRepository = petRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePet(
        PetCommand request)
    {
        var result = _validator.Validate(request);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToArray();
            return BadRequest(errors);
        }
        var command = _mapper.Map<PetCommand>((request));

        var createPetResult = await _mediator.Send(command);
        return createPetResult.Match(
            pet => Ok(_mapper.Map<PetResponse>(pet)),
            errors => Problem(errors));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var pets = _petRepository.GetAll();
        return Ok(pets);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var user = _petRepository.GetById(id);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, PetCommand request)
    {
        var result = _validator.Validate(request);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => new
            {
                x.PropertyName,
                x.ErrorMessage
            });
            return BadRequest(errors);
        }
        var previousPet = _petRepository.GetById(id);
        var mappedPet = _mapper.Map(request, previousPet);
        _petRepository.Update(mappedPet);
        return Ok(new { message = "Pet updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _petRepository.Delete(id);
        return Ok(new { message = "Pet deleted" });
    }
}
