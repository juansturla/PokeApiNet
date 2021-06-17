using PokeApp.ViewModels;
using PokeApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeApp.Views
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