using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurante_Proyecto.Data.Entities;
using Restaurante_Proyecto.Models;

namespace Restaurante_Proyecto.Data.Repository
{
    public class FoodMapRepository : IFoodMapRepository
    {
        private Restaurante_ProyectoDbContext dbContext;
        public FoodMapRepository(Restaurante_ProyectoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void DetachEntity<T>(T entity) where T : class
        {
            dbContext.Entry(entity).State = EntityState.Detached;
        }

        public void CreateDish(DishEntity dish)
        {
            dbContext.Entry(dish.Restaurant).State = EntityState.Unchanged;
            dbContext.Add(dish);
        }

        public void CreateRestaurant(RestaurantEntity restaurant)
        {
            dbContext.Add(restaurant);
        }

        public async Task DeleteDishAsync(int idDish)
        {
            var dishToDelete = await dbContext.Dishes.SingleAsync(d => d.Id == idDish);
            dbContext.Dishes.Remove(dishToDelete);
            
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            var restaurantToDelete = await dbContext.Restaurants.SingleAsync(r => r.Id == id);
            dbContext.Restaurants.Remove(restaurantToDelete);
        }

        public async Task<DishEntity> GetDishAsync(int idDish)
        {
            IQueryable<DishEntity> query = dbContext.Dishes;
            query = query.AsNoTracking();
            return await query.SingleAsync(d => d.Id == idDish);
        }

        public async Task<IEnumerable<DishEntity>> GetDishesAsync(int idRestaurant)
        {
            IQueryable<DishEntity> query = dbContext.Dishes;
            query = query.AsNoTracking();
            return await query.Where(d => d.Restaurant.Id == idRestaurant).ToArrayAsync();
        }

        public async Task<RestaurantEntity> GetRestaurantAsync(int id)
        {
            IQueryable<RestaurantEntity> query = dbContext.Restaurants;
            //Implement to show dishes later
            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RestaurantEntity>> GetRestaurantsAsync()
        {
            //Include orderBy and showDishes, later
            IQueryable<RestaurantEntity> query = dbContext.Restaurants;

            query = query.AsNoTracking();
            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await dbContext.SaveChangesAsync()) > 0;
        }

        public void UpdateRestaurant(int id, RestaurantEntity restaurant)
        {
            var restaurantToUpdate = dbContext.Restaurants.Single(r => r.Id == restaurant.Id);
            restaurantToUpdate.Name = restaurant.Name;
            restaurantToUpdate.Street = restaurant.Street;
            restaurantToUpdate.AddressNumber = restaurant.AddressNumber;
            restaurantToUpdate.FoodStyle = restaurant.FoodStyle;
            restaurantToUpdate.ImagePath = restaurant.ImagePath;
        }

        public void UpdateDish(DishEntity dish)
        {
            var dishToUpdate = dbContext.Dishes.Single(d => d.Id == dish.Id);
            dishToUpdate.Name = dish.Name;
            dishToUpdate.MainIngredient = dish.MainIngredient;
            dishToUpdate.Nationality = dish.Nationality;
            dishToUpdate.Size = dish.Size;
            dishToUpdate.Cost = dish.Cost;
            dishToUpdate.ImagePath = dish.ImagePath;
        }
    }
}
