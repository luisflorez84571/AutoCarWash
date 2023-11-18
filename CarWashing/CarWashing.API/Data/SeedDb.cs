using CarWashing.API.Helpers;
using CarWashing.Shared.Entities;
using CarWashing.Shared.Enums;

namespace CarWashing.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckRolesAsync();
            await CheckUserAsync("0001", "Luis", "Florez", "pinaef87@hotmail.com", "3148709090", "Calle 44 # 109", UserType.Admin);
            await CheckUserAsync("0002", "Isabel", "Garzon", "Isabel@hotmail.com", "322 311 4620", "Calle 44 # 109", UserType.User);

        }
        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }
        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {

                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    Celphone = phone,
                    Address = address,
                    Document = document,
                    UserType = userType,

                };

                await _userHelper.AddUserAsync(user, "Florez1949");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }

    }
}