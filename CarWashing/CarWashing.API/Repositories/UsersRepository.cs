using Microsoft.EntityFrameworkCore;
using CarWashing.API.Data;
using CarWashing.API.Helpers;
using CarWashing.Shared.DTOs;
using CarWashing.Shared.Entities;
using CarWashing.Shared.Responses;

namespace CarWashing.API.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Response<Client>> GetAsync(string email)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(x => x.Mail == email);

            if (client == null)
            {
                return new Response<Client>
                {
                    WasSuccess = false,
                    Message = "Usuario no encontrado"
                };
            }

            return new Response<Client>
            {
                WasSuccess = true,
                Result = client
            };
        }

        public async Task<Response<Client>> GetAsync(Guid clientId)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(x => x.ClientId.ToString() == clientId.ToString());

            if (client == null)
            {
                return new Response<Client>
                {
                    WasSuccess = false,
                    Message = "Usuario no encontrado"
                };
            }

            return new Response<Client>
            {
                WasSuccess = true,
                Result = client
            };
        }

        public async Task<Response<IEnumerable<Client>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Clients
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.FirstName.ToLower().Contains(pagination.Filter.ToLower()) ||
                                                    x.LastName.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new Response<IEnumerable<Client>>
            {
                WasSuccess = true,
                Result = await queryable
                     .ToListAsync()
            };
        }

        public async Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _context.Clients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.FirstName.ToLower().Contains(pagination.Filter.ToLower()) ||
                                                    x.LastName.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return new Response<int>
            {
                WasSuccess = true,
                Result = (int)totalPages
            };
        }
    }
}