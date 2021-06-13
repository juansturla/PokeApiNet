using PokeApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PokeApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}