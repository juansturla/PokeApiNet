using PokeApp_Maui8.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
 using Microsoft.Maui;using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace PokeApp_Maui8.Views
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