using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokeApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddPokemonAsync(T pokemon);
        Task<bool> UpdatePokemonAsync(T pokemon);
        Task<bool> DeletePokemonAsync(int id);
        Task<T> GetPokemonAsync(int id);
        Task<T> GetPokemonAsync(string pokename);
        Task<IEnumerable<T>> GetPokemonsAsync(int page);
    }
}
