using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiyasMatrimony.API.Models;

namespace SiyasMatrimony.API.Data
{
    public class MatrimonyRepository : IMatrimonyRepository
    {
        private readonly DataContext _dataContext;

        public MatrimonyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dataContext.Users.Include(p=>p.Photos).FirstOrDefaultAsync(p => p.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dataContext.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<IEnumerable<State>> GetStates()
        {
            var states = await _dataContext.States.ToListAsync();
            return states;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var countries = await _dataContext.Countries.ToListAsync();
            return countries;
        }
        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
