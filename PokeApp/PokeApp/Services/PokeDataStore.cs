using PokeApiNet;
using PokeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApp.Services
{
    public class PokeDataStore : IDataStore<Pokemon>
    {
        readonly List<Pokemon> items;
        // instantiate client

        PokeApiClient pokeClient = new PokeApiClient();
        public PokeDataStore()
        {
        }

        public async Task<bool> AddItemAsync(Pokemon item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Pokemon item)
        {
            var oldItem = items.Where((Pokemon arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {

            return await Task.FromResult(true);
        }

        public async Task<Pokemon> GetItemAsync(int id)
        {
            return null;
            // return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }
        public async Task<Pokemon> GetItemAsync(string pokename)
        {
            var pokes = await Task.Run(async () => pokeClient.GetResourceAsync<Pokemon>(pokename));

            return pokes.Result;
            // return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Pokemon>> GetItemsAsync(int page)
        {
            //páginas de 20 ponele
            int pageOffset = page * 20;
            // get a resource by name
            var pokes = await Task.Run(async()=> pokeClient.GetNamedResourcePageAsync<Pokemon>(20,pageOffset));
            var pokeResult = pokes.Result.Results;
            List<Pokemon> pokeList = new List<Pokemon>();
            pokeResult.ForEach(x => pokeList.Add(new Pokemon() { Name = x.Name }));
            return await Task.FromResult(pokeList);
        }
    }
}