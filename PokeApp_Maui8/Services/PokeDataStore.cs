using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApp_Maui8.Services
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
            var poke = await Task.Run(() => pokeClient.GetResourceAsync<Pokemon>(id));
            /*if (poke.Types.Count < 2)
            {
                var nulltipe = new PokeApiNet.PokemonType() {Type= new NamedApiResource<PokeApiNet.Type>() { Name = null } };
                poke.Types.Add(nulltipe);
            }*/
            return poke;
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
            int pageOffset = page * 5;
            List<Pokemon> pokeList = new List<Pokemon>();
            // get a resource by name
            for (int i = 0; i < 5; i++)
            {
                var poke = await Task.Run(() => pokeClient.GetResourceAsync<Pokemon>(pageOffset + i));
                pokeList.Add(poke);

            }
            return pokeList;
            //var pokes = await Task.Run(()=> pokeClient.GetNamedResourcePageAsync<Pokemon>(20,pageOffset));
            //var pokeResult = pokes.Results;
            //pokeResult.ForEach(x => pokeList.Add(new Pokemon() { Name = x.Name }));
            //return await Task.FromResult(pokeList);
        }
        //juanlindo♥yanihermosa♥
    }
}