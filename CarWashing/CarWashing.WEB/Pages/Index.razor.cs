using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using CarWashing.WEB.Repositories;
using CarWashing.WEB.AuthenticationProviders;
using CarWashing.Shared.DTOs;
using CarWashing.Shared.Entities;
using CarWashing.Shared.Responses;

namespace CarWashing.WEB.Pages
{
    public partial class Index
    {
        private int currentPage = 1;
        private int totalPages;
        private int counter = 0;
        private bool isAuthenticated;        

        [Inject] private IRepository repository { get; set; } = null!;

        [Inject] private SweetAlertService sweetAlertService { get; set; } = null!;

        [Inject] private NavigationManager navigationManager { get; set; } = null!;        

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; } = null!;

        [Parameter]
        [SupplyParameterFromQuery]
        public string Page { get; set; } = "";

        [Parameter]
        [SupplyParameterFromQuery]
        public string Filter { get; set; } = "";
              
        private async Task CheckIsAuthenticatedAsync()
        {
            try
            {
                var authenticationState = await authenticationStateTask;

                // Verificar nulos antes de acceder a IsAuthenticated
                if (authenticationState?.User?.Identity != null)
                {
                    isAuthenticated = authenticationState.User.Identity.IsAuthenticated;
                }
                else
                {
                    isAuthenticated = false; // O toma alguna acción predeterminada.
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera adecuada (puede registrarla, mostrar un mensaje, etc.)
                Console.WriteLine($"Error en CheckIsAuthenticatedAsync: {ex.Message}");
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                await CheckIsAuthenticatedAsync();
            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera adecuada (puede registrarla, mostrar un mensaje, etc.)
                Console.WriteLine($"Error en OnParametersSetAsync: {ex.Message}");
            }
        }
               
    }
}