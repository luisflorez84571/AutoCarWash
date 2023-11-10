using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using CarWashing.API.Services;
using CarWashing.Shared.Entities;
using CarWashing.Shared.Enums;
using CarWashing.API.Helpers;
using CarWashing.API.Data;

namespace CarWashing.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IApiService _apiService;
        private readonly IUserHelper _userHelper;
        private readonly IFileStorage _fileStorage;
        private readonly IRuntimeInformationWrapper _runtimeInformationWrapper;

        public SeedDb(DataContext context, IApiService apiService, IUserHelper userHelper, IFileStorage fileStorage, IRuntimeInformationWrapper runtimeInformationWrapper)
        {
            _context = context;
            _apiService = apiService;
            _userHelper = userHelper;
            _fileStorage = fileStorage;
            _runtimeInformationWrapper = runtimeInformationWrapper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            //await CheckCountriesAsync();            
            await CheckRolesAsync();
            await CheckUserAsync("0001", "Luis", "Florez", "pinef87@yopmail.com", "3148709090", "Calle 44 # 109", UserType.Admin);
            await CheckUserAsync("0002", "Ledys", "Bedoya", "ledys@yopmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.User);
            
        }       
        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address,  UserType userType)
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
                    PhoneNumber = phone,
                    Document = document,                    
                    UserType = userType,
                    
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }        
        
    }
}