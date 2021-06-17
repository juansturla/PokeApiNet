using PokeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeApp.Views
{
    public partial class NewPokemonPage : ContentPage
    {

        public NewPokemonPage()
        {
            InitializeComponent();
            BindingContext = new NewPokemonViewModel();
        }
    }
}