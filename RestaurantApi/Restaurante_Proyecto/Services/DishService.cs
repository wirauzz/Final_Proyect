using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Restaurante_Proyecto.Data.Entities;
using Restaurante_Proyecto.Data.Repository;
using Restaurante_Proyecto.Exceptions;
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
            if(dish.RestaurantId != null && idRestaurant != dish.RestaurantId)
            {
                throw new WrongOperationException("Restaurant from URL and the one specified in the id has to be the same");
            }
            dish.RestaurantId = idRestaurant;
            var restaurantEntity = await ValidateRestaurant(idRestaurant);
            var dishEntity = mapper.Map<DishEntity>(dish);
            dishEntity.Restaurant = restaurantEntity;
            foodRepository.CreateDish(dishEntity);

            if(await foodRepository.SaveChangesAsync())
            {
                return mapper.Map<Dish>(dishEntity);
            }
            throw new ChangesNotExecutedException("There was an error including the Dish in the DB");

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
                throw new NotFoundItemException("The dish was not found in the DB");
            }
            var dish = mapper.Map<Dish>(dishEntity);
            dish.RestaurantId = idRestaurant;
            return dish;
        }

        public async Task<IEnumerable<Dish>> GetDishesAsync(int idRestaurant)
        {
            var restaurant = await ValidateRestaurant(idRestaurant);
            var dishesEntities = await foodRepository.GetDishesAsync(idRestaurant);
            var dishesList = mapper.Map<IEnumerable<Dish>>(dishesEntities);
            foreach(Dish d in dishesList)
            {
                d.RestaurantId = idRestaurant;
            }
            return dishesList;
        }

        public async Task<Dish> UpdateDishAsync(int idRestaurant, int idDish, Dish dish)
        {
            if(idDish !=dish.Id)
            {
                throw new WrongOperationException("Id of the dish in URL needs to be the same that the object");
            }
            var restaurant = await ValidateRestaurant(idRestaurant);
            if(idRestaurant!=restaurant.Id)
            {
                throw new NotFoundItemException("This restaurant has never met this dish");
            }
            dish.Id = idDish;
            var dishEntity = mapper.Map<DishEntity>(dish);
            foodRepository.UpdateDish(dishEntity);
            if (await foodRepository.SaveChangesAsync())
                return mapper.Map<Dish>(dishEntity);
            throw new ChangesNotExecutedException("There was an error with the database");
        }
        public async Task<RestaurantEntity> ValidateRestaurant(int idRestaurant)
        {
            var restaurant = await foodRepository.GetRestaurantAsync(idRestaurant);
            if (restaurant == null)
                throw new Exception("The Restaurant is not registrated in the DB");
            foodRepository.DetachEntity(restaurant);
            return restaurant;
        }

        public async Task<IEnumerable<Dish>> GetAllDishesAsync()
        {
            var allRestaurants = await foodRepository.GetRestaurantsAsync();
            List<Dish> allDishes = new List<Dish>();
            foreach(RestaurantEntity r in allRestaurants)
            {
                var restaurantId = r.Id;
                var dishes = await GetDishesAsync(restaurantId);
                foreach(Dish d in dishes)
                {
                    allDishes.Add(d);
                }   
            }
            return allDishes;
        }
    }
}
