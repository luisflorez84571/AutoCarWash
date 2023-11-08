using Blazored.Modal.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using CarWashing.WEB.Repositories;
using CarWashing.WEB.Services;
using CarWashing.Shared.DTOs;
using CarWashing.Shared.Entities;

namespace CarWashing.WEB.Pages.Auth
{
    public partial class EditUser
    {
        [Inject] private NavigationManager navigationManager { get; set; } = null!;

        [Inject] private IRepository repository { get; set; } = null!;

        [Inject] private SweetAlertService sweetAlertService { get; set; } = null!;

        [Inject] private ILoginService loginService { get; set; } = null!;

        private User user;
        private bool loading;

        [CascadingParameter]
        private IModalService Modal { get; set; } = default!;

        private void ShowModal()
        {
            Modal.Show<ChangePassword>();
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadUserAsyc();            
        }

        private async Task LoadUserAsyc()
        {
            var responseHTTP = await repository.GetAsync<User>($"/api/accounts");
            if (responseHTTP.Error)
            {
                if (responseHTTP.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("/");
                    return;
                }
                var messageError = await responseHTTP.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", messageError, SweetAlertIcon.Error);
                return;
            }
            user = responseHTTP.Response;
        }         

        private async Task SaveUserAsync()
        {
            loading = true;
            var responseHttp = await repository.PutAsync<User, TokenDTO>("/api/accounts", user!);
            loading = false;
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            await loginService.LoginAsync(responseHttp.Response!.Token);
            navigationManager.NavigateTo("/");
        }
    }
}