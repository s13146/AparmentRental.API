using AparmentRental.Core.DTO;
using AparmentRental.Core.Services;

namespace AparmentRental.API.Controllers;

using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class LandLordController : ControllerBase
{
    private readonly ILandlordService _landlordService;

    public LandLordController(ILandlordService landlordService)
    {
        _landlordService = landlordService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateNewLandLordAccount([FromBody] LandlordCreationRequestDto dto)
    {
        await _landlordService.AddNewLandlordAsync(dto);
        return NoContent();
    }
    
}