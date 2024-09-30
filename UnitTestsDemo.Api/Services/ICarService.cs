namespace UnitTestsDemo.Api.Services;

public interface ICarService
{
    Task<List<string>> GetModels(string make);
}
