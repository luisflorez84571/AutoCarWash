using CarWashing.Shared.Responses;

namespace CarWashing.API.Services
{
    public interface IApiService
    {
        Task<Response<T>> GetAsync<T>(string servicePrefix, string controller);
    }
}