using PokeApp_Maui8.ViewModels;
using Microsoft.Maui.Controls;

namespace PokeApp_Maui8.Views
{
    public partial class PokemonsPage : ContentPage
    {
        PokemonsViewModel _viewModel;

        public PokemonsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PokemonsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}