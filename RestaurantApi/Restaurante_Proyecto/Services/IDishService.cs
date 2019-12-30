using Restaurante_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante_Proyecto.Services
{
    public interface IDishService
    {
        Task<Dish> GetDishAsync(int idRestaurant, int idDish);
        Task<IEnumerable<Dish>> GetDishesAsync(int idRestaurant);
        Task<bool> DeleteDish(int idRestaurant, int idDish);
        Task<Dish> CreateDishAsync(int idRestaurant, Dish dish);
        Task<Dish> UpdateDishAsync(int idRestaurant, int idDish, Dish dish);
        Task<IEnumerable<Dish>> GetAllDishesAsync();


    }
}
