
using Blazored.LocalStorage;
using LoftPM.Client.Authentication;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LoftPM.Client.Shared
{
    public partial class MainLayout
    {

       // [Inject]
        //public ILocalStorageService LocalStorage { get; set; }

        bool _drawerOpen = true;
        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        private async Task Logout()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)authStateProvider;
            await customAuthStateProvider.UpdateAuthenticationState(null);
            navManager.NavigateTo("/", true);
        }
 

        MudTheme _currentTheme = null;

        MudTheme _darkTheme = new MudTheme
        {
            Palette = new Palette
            {
                AppbarBackground = "#00A24B",
                AppbarText = "#FAFAFA",
                Primary = "#00A24B",
               
                Background = "#FAFAFA",
                
                DrawerBackground = "#E0F2F1",
                DrawerText = "#00A24B",
                Surface = "#E0F2F1",
            }
        };

        protected async override Task OnInitializedAsync()
        {
            _currentTheme = _darkTheme;
        }

    }
}