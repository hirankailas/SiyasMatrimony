using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using SiyasMatrimony.API.Data;
using SiyasMatrimony.API.Models;
using Microsoft.Extensions.Configuration;

namespace DatingApp.API.Data
{
    public class Seed
    {
        private readonly UserManager<User> _userManager;

        //private readonly DataContext _context;

        //public Seed(IdentityUserManager context)
        //{
        //    _context = context;
        //}
        private readonly IMatrimonyRepository _repo;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _confiduration;

        public Seed(UserManager<User> userManager, IMatrimonyRepository repo, 
                    RoleManager<Role> roleManager,IConfiguration  confiduration)
        {
            _roleManager = roleManager;
            _confiduration = confiduration;
            _repo = repo;
            _userManager = userManager;
        }

        public void SeedUsers()
        {
            if (!_userManager.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                var roles = new List<Role>{
                    new Role{Name = "Member"},
                    new Role{Name = "Admin"},
                    new Role{Name = "Moderator"}
                }; 

                foreach(var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }

                foreach (var user in users)
                {
                    //byte[] passwordHash,passwordSalt;
                    //CreatePasswordHash("password",out passwordHash,out passwordSalt);
                    //user.PasswordHash = passwordHash;
                    //user.PasswordSalt = passwordSalt;
                    //user.UserName = user.UserName.ToLower();
                    //_context.Users.Add(user);
                    _userManager.CreateAsync(user, "password").Wait();
                    _userManager.AddToRoleAsync(user,"Member").Wait();
                }

                var adminUser1 = new User
                {
                    UserName = "Siya",
                    Email = "hirankailas@gmail.com"
                };

                IdentityResult result = _userManager.CreateAsync(adminUser1, "password").Result;

                if(result.Succeeded)
                {
                    var admin1 = _userManager.FindByNameAsync(adminUser1.UserName).Result;
                    _userManager.AddToRoleAsync(admin1,"Admin");

                }

                var adminUser2 = new User
                {
                    UserName = "Hiran",
                    Email = "hirankailas@gmail.com"
                };

                result = _userManager.CreateAsync(adminUser2, "password").Result;

                 if(result.Succeeded)
                 {
                     var admin2 = _userManager.FindByNameAsync(adminUser2.UserName).Result;
                     var adminroles = new[] {"Admin","Moderator"};
                     _userManager.AddToRoleAsync(admin2, "Admin").Wait();
                     _userManager.AddToRoleAsync(admin2, "Moderator").Wait();
                 }
                
            }

            //_context.SaveChanges();
        }

        public void SeedCountries()
        {
            var countryData = System.IO.File.ReadAllText("Data/countries.json");
            var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);

            foreach (var country in countries)
            {
                _repo.Add(country);
            }
            _repo.SaveAll();
        }
        public void SeedStates()
        {
            var stateData = System.IO.File.ReadAllText("Data/states.json");
            var states = JsonConvert.DeserializeObject<List<State>>(stateData);

            foreach (var state in states)
            {
                _repo.Add(state);
            }
            _repo.SaveAll();
        }

        public void SeedCities()
        {
            var cityData = System.IO.File.ReadAllText("Data/cities.json");
            var cities = JsonConvert.DeserializeObject<List<City>>(cityData);

            foreach (var city in cities)
            {
                _repo.Add(city);
            }
            _repo.SaveAll();
        }

        public void UpdateCountryIds()
        {
            // List<Country> countries = _repo.GetCountries().Result.ToList();
            List<State> states = _repo.GetStates().Result.ToList();

            foreach (var item in states)
            {
                item.country_id = item.Country.id;
            }
            _repo.SaveAll();
        }

        // private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using(var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwordSalt=hmac.Key;
        //        passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}
    }
}