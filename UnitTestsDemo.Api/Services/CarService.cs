
namespace UnitTestsDemo.Api.Services;

public class CarService : ICarService
{
    public Task<List<string>> GetModels(string make) => make switch
    {
        "Honda" => Task.FromResult(new List<string>() { "Civic", "Accord", "CR-V" }),
        "Tesla" => Task.FromResult(new List<string>() { "Model S", "Model Y" }),
        "Ford" => Task.FromResult(new List<string>() { "Mustang" }),
        _ => throw new ArgumentException("Invalid car make")
    };
}