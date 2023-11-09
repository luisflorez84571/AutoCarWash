using CarWashing.Shared.DTOs;
using CarWashing.Shared.Entities;
using CarWashing.Shared.Responses;

namespace CarWashing.API.Repositories
{
    public interface IUsersRepository
    {
        Task<Response<Client>> GetAsync(string email);

        Task<Response<Client>> GetAsync(Guid clientId);

        Task<Response<IEnumerable<Client>>> GetAsync(PaginationDTO pagination);

        Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}