using PokeApiNet;
using PokeApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeApp.ViewModels
{
    public class PokemonsViewModel : BaseViewModel
    {
        private Pokemon _selectedPokemon;

        public ObservableCollection<Pokemon> Pokemons { get; }
        public Command LoadPokemonsCommand { get; }
        public Command AddPokemonCommand { get; }
        public Command<Pokemon> PokemonTapped { get; }

        public PokemonsViewModel()
        {
            Title = "Browse";
            Pokemons = new ObservableCollection<Pokemon>();
            LoadPokemonsCommand = new Command(async () => await ExecuteLoadPokemonsCommand());
           
            PokemonTapped = new Command<Pokemon>(OnPokemonSelected);

            AddPokemonCommand = new Command(OnAddPokemon);
        }

        async Task ExecuteLoadPokemonsCommand()
        {
            IsBusy = true;

            try
            {
                Pokemons.Clear();
                //var pokemons = await DataStore.GetPokemonsAsync(0);
                //foreach (var pokemon in pokemons)
                //{
                //
                //    Pokemons.Add(pokemon);
                //}
                //KeepLoadingPokemons();
                LoadAllPokemonsDeUna();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void KeepLoadingPokemons()
        {
            for (int i = 1; i < 150; i++)
            {
                var pokemon = await DataStore.GetPokemonAsync(i);
                Pokemons.Add(pokemon);
            }
        }
        private async void LoadAllPokemonsDeUna()
        {
            int i = 1;
            while (i < 150)
            {
                try
                {
                    var pokemon = await DataStore.GetPokemonAsync(i);

                    Pokemons.Add(pokemon);
                    i++;
                }
                catch (Exception) { }
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPokemon = null;
        }

        public Pokemon SelectedPokemon
        {
            get => _selectedPokemon;
            set
            {
                SetProperty(ref _selectedPokemon, value);
                OnPokemonSelected(value);
            }
        }

        private async void OnAddPokemon(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPokemonPage));
        }

        async void OnPokemonSelected(Pokemon pokemon)
        {
            if (pokemon == null)
                return;

            // This will push the PokemonDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PokemonDetailPage)}?{nameof(PokemonDetailViewModel.PokeName)}={pokemon.Name}");
        }
    }
}