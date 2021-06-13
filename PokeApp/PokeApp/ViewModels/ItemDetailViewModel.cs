using PokeApiNet;
using PokeApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    [QueryProperty(nameof(PokeName), nameof(PokeName))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private string _pokename;
        private string text;
        private string description;
        private Pokemon _selectedPokemon;
        public Pokemon SelectedPokemon 
        { 
            get=> _selectedPokemon; 
            set =>SetProperty(ref _selectedPokemon, value); 
        }
        public int Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }
        public string PokeName
        {
            get
            {
                return _pokename;
            }
            set
            {
                _pokename = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Name;
                //Description = item.;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public async void LoadItemId(string _pokename)
        {
            try
            {
                SelectedPokemon = await DataStore.GetItemAsync(_pokename);
                Id = SelectedPokemon.Id;
                Text = SelectedPokemon.Name;
                //Description = item.;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
