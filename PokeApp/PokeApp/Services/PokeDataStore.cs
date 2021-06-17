using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApp.Services
{
    public class PokeDataStore : IDataStore<Pokemon>
    {
        readonly List<Pokemon> pokemons;
        // instantiate client

        PokeApiClient pokeClient = new PokeApiClient();
        public PokeDataStore()
        {
        }

        public async Task<bool> AddPokemonAsync(Pokemon pokemon)
        {
            pokemons.Add(pokemon);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePokemonAsync(Pokemon pokemon)
        {
            var oldPokemon = pokemons.Where((Pokemon arg) => arg.Id == pokemon.Id).FirstOrDefault();
            pokemons.Remove(oldPokemon);
            pokemons.Add(pokemon);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePokemonAsync(int id)
        {

            return await Task.FromResult(true);
        }

        public async Task<Pokemon> GetPokemonAsync(int id)
        {
            return null;
            // return await Task.FromResult(pokemons.FirstOrDefault(s => s.Id == id));
        }
        public async Task<Pokemon> GetPokemonAsync(string pokename)
        {
            var pokes = await Task.Run(() => pokeClient.GetResourceAsync<Pokemon>(pokename));

            return pokes;
            // return await Task.FromResult(pokemons.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsAsync(int page)
        {
            //páginas de 20 ponele
            int pageOffset = page * 20;
            // get a resource by name
            var pokes = await Task.Run(()=> pokeClient.GetNamedResourcePageAsync<Pokemon>(20,pageOffset));
            var pokeResult = pokes.Results;
            List<Pokemon> pokeList = new List<Pokemon>();
            pokeResult.ForEach(x => pokeList.Add(new Pokemon() { Name = x.Name }));
            return await Task.FromResult(pokeList);
        }
        //juanlindo♥yanihermosa♥
    }
}