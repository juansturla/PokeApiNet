using PokeApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PokeApp.Views
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