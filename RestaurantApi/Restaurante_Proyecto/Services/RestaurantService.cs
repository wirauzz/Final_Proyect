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
    public class RestaurantService : IRestaurantService
    {
        private IFoodMapRepository foodRepository;
        private readonly IMapper mapper;
        public RestaurantService(IFoodMapRepository foodRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.mapper = mapper;
        }
        public async Task<Restaurant> CreateRestaurantAsync(Restaurant restaurant)
        {
            var restaurantEntity = mapper.Map<RestaurantEntity>(restaurant);
            foodRepository.CreateRestaurant(restaurantEntity);
            if(await foodRepository.SaveChangesAsync())
            {
                return mapper.Map<Restaurant>(restaurantEntity);
            }
            throw new ChangesNotExecutedException("There was an error with the database");
        }

        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            await validateRestaurant(id);
            await foodRepository.DeleteRestaurantAsync(id);
            if (await foodRepository.SaveChangesAsync())
                return true;
            return false;
        }

        public async Task<Restaurant> GetRestaurantAsync(int id)
        {
            var restaurant = await foodRepository.GetRestaurantAsync(id);
            if (restaurant == null)
                throw new NotFoundItemException("Restaurant not found");
            return mapper.Map<Restaurant>(restaurant);
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            var restaurantEntities = await foodRepository.GetRestaurantsAsync();
            return mapper.Map<IEnumerable<Restaurant>>(restaurantEntities);
        }

        public async Task<Restaurant> UpdateRestaurantAsync(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id && restaurant.Id != null )
                throw new WrongOperationException("URL id needs to be the same than the one sent");
            await validateRestaurant(id);
            restaurant.Id = id;
            var restaurantEntity = mapper.Map<RestaurantEntity>(restaurant);
            foodRepository.UpdateRestaurant(id, restaurantEntity);
            if (await foodRepository.SaveChangesAsync())
                return mapper.Map<Restaurant>(restaurantEntity);
            throw new ChangesNotExecutedException("There was an error with the database");
        }

        private async Task validateRestaurant(int id)
        {
            var restaurant = await foodRepository.GetRestaurantAsync(id);
            if (restaurant == null)
                throw new NotFoundItemException("Cannot find the restaurant");
            foodRepository.DetachEntity(restaurant);
        }

    }
}
