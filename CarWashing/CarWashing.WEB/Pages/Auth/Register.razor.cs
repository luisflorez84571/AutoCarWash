using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using CarWashing.WEB.Repositories;
using CarWashing.Shared.DTOs;
using CarWashing.Shared.Entities;
using CarWashing.Shared.Enums;

namespace CarWashing.WEB.Pages.Auth
{
    public partial class Register
    {
        [Inject] private NavigationManager navigationManager { get; set; } = null!;

        [Inject] private IRepository repository { get; set; } = null!;

        [Inject] private SweetAlertService sweetAlertService { get; set; } = null!;

        [Parameter]
        [SupplyParameterFromQuery]
        public bool IsAdmin { get; set; }

        private UserDTO userDTO = new();        
        private bool loading;        

        private async Task CreteUserAsync()
        {
            loading = true;
            userDTO.UserName = userDTO.Email;
            userDTO.UserType = UserType.User;

            if (IsAdmin)
            {
                userDTO.UserType = UserType.Admin;
            }

            var responseHttp = await repository.PostAsync<UserDTO>("/api/accounts/CreateUser", userDTO);
            loading = false;
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            await sweetAlertService.FireAsync("Confirmación", "Su cuenta ha sido creada con éxito. Se te ha enviado un correo electrónico con las instrucciones para activar tu usuario.", SweetAlertIcon.Info);
            navigationManager.NavigateTo("/");
        }
    }
}