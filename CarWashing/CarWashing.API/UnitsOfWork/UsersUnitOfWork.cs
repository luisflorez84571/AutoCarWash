using CarWashing.API.Repositories;
using CarWashing.Shared.DTOs;
using CarWashing.Shared.Entities;
using CarWashing.Shared.Responses;

namespace CarWashing.API.UnitsOfWork
{
    public class UsersUnitOfWork : IUsersUnitOfWork
    {
        private readonly IUsersRepository _usersRepository;

        public UsersUnitOfWork(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Response<Client>> GetAsync(String email) => await _usersRepository.GetAsync(email);

        public async Task<Response<Client>> GetAsync(Guid clientId) => await _usersRepository.GetAsync(clientId);

        public async Task<Response<IEnumerable<Client>>> GetAsync(PaginationDTO pagination) => await _usersRepository.GetAsync(pagination);

        public async Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _usersRepository.GetTotalPagesAsync(pagination);
    }
}