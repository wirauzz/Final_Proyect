using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante_Proyecto.Models;
using Restaurante_Proyecto.Services;

namespace Restaurante_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantService restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            try
            {
                return Ok(await restaurantService.GetRestaurantsAsync());
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            try
            {
                return Ok(await restaurantService.GetRestaurantAsync(id));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteRestaurant(int id)
        {
            try
            {
                return Ok(await restaurantService.DeleteRestaurantAsync(id));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                return Ok(await restaurantService.CreateRestaurantAsync(restaurant));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Restaurant>> PutRestaurant(int id, [FromBody] Restaurant restaurant)
        {
            try
            {
                return Ok(await restaurantService.UpdateRestaurantAsync(id, restaurant));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }
    }
}