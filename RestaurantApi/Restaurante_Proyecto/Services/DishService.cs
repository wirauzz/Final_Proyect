using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Restaurante_Proyecto.Data.Entities;
using Restaurante_Proyecto.Data.Repository;
using Restaurante_Proyecto.Models;

namespace Restaurante_Proyecto.Services
{
    public class DishService : IDishService
    {
        private IFoodMapRepository foodRepository;
        private readonly IMapper mapper;
        public DishService(IFoodMapRepository foodRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.mapper = mapper;
        }
        public async Task<Dish> CreateDishAsync(int idRestaurant, Dish dish)
        {
            //var rest = ValidateRestaurant(idRestaurant);
            if(dish.RestautantId != null && idRestaurant != dish.RestautantId)
            {
                throw new Exception("Non valid Restaurant");
            }
            dish.RestautantId = idRestaurant;
            var restaurantEntity = await ValidateRestaurant(idRestaurant);
            var dishEntity = mapper.Map<DishEntity>(dish);
            dishEntity.Restaurant = restaurantEntity;
            foodRepository.CreateDish(dishEntity);

            if(await foodRepository.SaveChangesAsync())
            {
                return mapper.Map<Dish>(dishEntity);
            }
            throw new Exception("There was an error with the DB");

        }

        public async Task<bool> DeleteDish(int idRestaurant, int idDish)
        {
            var rest = ValidateRestaurant(idRestaurant);
            await foodRepository.DeleteDishAsync(idDish);
            if (await foodRepository.SaveChangesAsync())
                return true;
            return false;
        }

        public async Task<Dish> GetDishAsync(int idRestaurant, int idDish)
        {
            var rest = ValidateRestaurant(idRestaurant);
            var dishEntity = await foodRepository.GetDishAsync(idDish);
            if(dishEntity == null)
            {
                throw new Exception("Not Found");
            }
            var dish = mapper.Map<Dish>(dishEntity);
            dish.RestautantId = idRestaurant;
            return dish;
        }

        public async Task<IEnumerable<Dish>> GetDishesAsync(int idRestaurant)
        {
            var dishesEntities = await foodRepository.GetDishesAsync(idRestaurant);
            var dishesList = mapper.Map<IEnumerable<Dish>>(dishesEntities);
            foreach(Dish d in dishesList)
            {
                d.RestautantId = idRestaurant;
            }
            return dishesList;
        }

        public async Task<Dish> UpdateDishAsync(int idRestaurant, int idDish, Dish dish)
        {
            if(idDish !=dish.Id)
            {
                throw new Exception("Id of the dish in URL needs to be the same that the object");
            }
            var restaurant = await ValidateRestaurant(idRestaurant);
            if(idRestaurant!=restaurant.Id)
            {
                throw new Exception("This restaurant has never met this dish");
            }
            dish.Id = idDish;
            var dishEntity = mapper.Map<DishEntity>(dish);
            foodRepository.UpdateDish(dishEntity);
            if (await foodRepository.SaveChangesAsync())
                return mapper.Map<Dish>(dishEntity);
            throw new Exception("There was an error with the database");
        }
        public async Task<RestaurantEntity> ValidateRestaurant(int idRestaurant)
        {
            var restaurant = await foodRepository.GetRestaurantAsync(idRestaurant);
            if (restaurant == null)
                throw new Exception("Not found");
            foodRepository.DetachEntity(restaurant);
            return restaurant;
        }
    }
}
