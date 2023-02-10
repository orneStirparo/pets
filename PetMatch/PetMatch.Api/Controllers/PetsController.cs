using PetMatch.Application.Pets.Commands.CreatePet;
using PetMatch.Contracts.Pets;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetMatch.Application.Common.Interfaces.Persistance;
using PetMatch.Domain.Pets;
using PetMatch.Domain.Pets.ValueObjects;

namespace PetMatch.Api.Controllers;

[Route("pets")]
public class PetsController : ApiController
{
    private readonly IMapper _mapper;

    private readonly IPetRepository _petRepository; 
    private readonly ISender _mediator;

    public PetsController(IMapper mapper, ISender mediator, IPetRepository petRepository)
    {
        _petRepository = petRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePet(
        CreatePetRequest request)
    {
        var command = _mapper.Map<CreatePetCommand>((request));

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
    public IActionResult Update(Guid id, UpdatePetRequest pet)
    {
        var previousPet = _petRepository.GetById(id);
        var mappedPet = _mapper.Map(pet, previousPet);
        _petRepository.Update(mappedPet);
        return Ok(new { message = "User updated" });
    }


    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {
    //     _petRepository.Delete(id);
    //     return Ok(new { message = "Pet deleted" });
    // }
    }
