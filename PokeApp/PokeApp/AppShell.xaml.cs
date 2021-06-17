using PokeApp.ViewModels;
using PokeApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PokeApp
{
    public partial class AppShell : Xamarin.Forms.Shell
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
