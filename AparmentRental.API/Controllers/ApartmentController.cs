using AparmentRental.Core.DTO;
using AparmentRental.Core.Services;
using AparmentRental.Infastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AparmentRental.API.Controllers;



[ApiController]
[Route("api/[controller]")]
public class AparmentController : ControllerBase
{
    private readonly IApartmentService _apartmentService;

    public AparmentController(IApartmentService apartmentService)
    {
        _apartmentService = apartmentService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewApartment([FromBody] ApartmentCreationRequestDto dto)
    {
        try
        {
            await _apartmentService.AddNewApartmentToExistingLandLordAsync(dto);
        }
        catch (EntityNotFoundException)
        {
            return BadRequest();
        }
        return NoContent();
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _apartmentService.GetAllApartmentsBasicInfosAsync());
    }

    [HttpGet("GetTheCheapest")]
    public async Task<IActionResult> GetTheCheapestApartment()
    {
        var apartment = await _apartmentService.GetTheCheapestApartmentAsync();
        return Ok(apartment);
    }
}
