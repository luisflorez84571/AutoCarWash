using CarWashing.Shared.Responses;

namespace CarWashing.API.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }
}
