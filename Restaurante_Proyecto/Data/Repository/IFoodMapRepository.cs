using Restaurante_Proyecto.Data.Entities;
using Restaurante_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante_Proyecto.Data.Repository
{
    public interface IFoodMapRepository
    {
        //For every change
        Task<bool> SaveChangesAsync();

        //Restaurant's Methods
        Task<IEnumerable<RestaurantEntity>> GetRestaurantsAsync();
        Task<RestaurantEntity> GetRestaurantAsync(int id);
        Task DeleteRestaurantAsync(int id);
        void CreateRestaurant(RestaurantEntity restaurant);
        void UpdateRestaurant(int id, RestaurantEntity restaurant);

        //Dishes Methods
        Task<DishEntity> GetDishAsync(int idDish);
        Task<IEnumerable<DishEntity>> GetDishesAsync(int idRestaurant);
        Task DeleteDishAsync(int idDish);
        void CreateDish(DishEntity dish);
        void UpdateDish(DishEntity dish);

        Task DeleteDishWithRestaurantId(int idRestaurant);

        //Exceptional Dish Method -> Get all Dishes from DB
        Task<IEnumerable<DishEntity>> GetAllDishes();

        void DetachEntity<T>(T entity) where T : class;
    }
}
