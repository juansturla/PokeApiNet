using PokeApp_Maui8.ViewModels;
using PokeApp_Maui8.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;

namespace PokeApp_Maui8
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PokemonDetailPage), typeof(PokemonDetailPage));
            Routing.RegisterRoute(nameof(NewPokemonPage), typeof(NewPokemonPage));
        }

        private async void OnMenuPokemonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
