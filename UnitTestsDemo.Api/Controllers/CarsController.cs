using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UnitTestsDemo.Api.Services;

namespace UnitTestsDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarService carsService;

    public CarsController(ICarService carsService)
    {
        this.carsService = carsService;
    }

    [HttpGet("{make}/models")]
    public async Task<Results<Ok<string>, BadRequest>> Get(string make)
    {
        if (string.IsNullOrWhiteSpace(make))
        {
            return TypedResults.BadRequest();
        }

        await carsService.GetModels(make);

        return TypedResults.Ok(make);
    }
}
