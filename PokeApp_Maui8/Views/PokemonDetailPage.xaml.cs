using PokeApp_Maui8.ViewModels;
using System.ComponentModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace PokeApp_Maui8.Views
{
    public partial class PokemonDetailPage : ContentPage
    {
        public PokemonDetailPage()
        {
            InitializeComponent();
            BindingContext = new PokemonDetailViewModel();
        }
    }
}