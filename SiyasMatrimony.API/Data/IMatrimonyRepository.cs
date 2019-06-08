using SiyasMatrimony.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiyasMatrimony.API.Data
{
    public interface IMatrimonyRepository
    {
        void Add<T>(T entity) where T : class;
        void delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<IEnumerable<State>> GetStates();
        Task<IEnumerable<Country>> GetCountries();
    }
}
