using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext; // context baz danych 
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
               if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants); 
                    _dbContext.SaveChanges();          // zapisujmey zmiany na bazie danych
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "Wierzynek",
                    Category = "Ekskluzywna restauracja",
                    Description =
                        "Restauracja mieszcząca się w Krakowie przy Rynku Głównym. Założona została w 1945 przez Kazimierza Książka jako restauracja Pod Wierzynkiem",
                    ContactEmail = "wierzynek@restaurant.pl",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Kotlet",
                            Price = 15.50M,
                        },

                        new Dish()
                        {
                            Name = "Ziemniaki Pieczone",
                            Price = 6.70M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Rynek Główny 16",
                        PostalCode = "30-008"
                    }
                },
                new Restaurant()
                {
                    Name = "Warszawianka",
                    Category = "Standard",
                    Description =
                        "Najlepsza restauracja w mieście",
                    HasDelivery = true,
                    Address = new Address()
                    {
                        City = "Krzeszowice",
                        Street = "Rynek 24",
                        PostalCode = "32-065"
                    }
                }
            };

            return restaurants;
        }
        }
}
