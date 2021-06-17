using PokeApiNet;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    [QueryProperty(nameof(PokemonId), nameof(PokemonId))]
    [QueryProperty(nameof(PokeName), nameof(PokeName))]
    public class PokemonDetailViewModel : BaseViewModel
    {
        private int pokemonId;
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

        public int PokemonId
        {
            get
            {
                return pokemonId;
            }
            set
            {
                pokemonId = value;
                LoadPokemonId(value);
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
                LoadPokemonId(value);
            }
        }

        public async void LoadPokemonId(int pokemonId)
        {
            
            try
            {
                var pokemon = await DataStore.GetPokemonAsync(pokemonId);
                Id = pokemon.Id;
                Text = pokemon.Name;
                //Description = pokemon.;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Pokemon");
            }
        }
        public async void LoadPokemonId(string _pokename)
        {
            try
            {
                SelectedPokemon = await DataStore.GetPokemonAsync(_pokename);
                Id = SelectedPokemon.Id;
                Text = SelectedPokemon.Name;
                //Description = pokemon.;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Load Pokemon");
            }
        }
    }
}
