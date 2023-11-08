using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using CarWashing.WEB.Repositories;
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

        protected override async Task OnParametersSetAsync()
        {
            await CheckIsAuthenticatedAsync();                   
        }        

        private async Task CheckIsAuthenticatedAsync()
        {
            var authenticationState = await authenticationStateTask;
            isAuthenticated = authenticationState.User.Identity!.IsAuthenticated;
        }
        
    }
}