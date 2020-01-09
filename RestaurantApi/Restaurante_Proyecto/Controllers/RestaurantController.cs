using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante_Proyecto.Models;
using Restaurante_Proyecto.Services;
using Restaurante_Proyecto.Exceptions;

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
                var restaurantsList = await restaurantService.GetRestaurantsAsync();
                if(!restaurantsList.Any())
                {
                    return BadRequest("There was an error with the DB");
                }
                return Ok(restaurantsList);
            }
            catch
            {
                return NotFound("There was an error with the DB");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            try
            {
                return Ok(await restaurantService.GetRestaurantAsync(id));
            }
            catch (NotFoundItemException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch
            {
                return BadRequest("There was an error with the DB");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteRestaurant(int id)
        {
            try
            {
                if(await restaurantService.DeleteRestaurantAsync(id))
                {
                    return this.StatusCode(StatusCodes.Status410Gone, "Restaurant was deleted");
                }
                return this.StatusCode(StatusCodes.Status404NotFound, "Restaurant was no deleted");
            }
            catch (NotFoundItemException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch
            {
                return BadRequest("There was an error with the DB");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                var restaurantCreated = await restaurantService.CreateRestaurantAsync(restaurant);
                return Created($"api/Restaurant/{restaurantCreated.Id}",restaurantCreated);
            }
            catch (NotFoundItemException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ChangesNotExecutedException ex)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "There was an error with the DB");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Restaurant>> PutRestaurant(int id, [FromBody] Restaurant restaurant)
        {
            try
            {
                return Ok(await restaurantService.UpdateRestaurantAsync(id, restaurant));
            }
            catch (NotFoundItemException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ChangesNotExecutedException ex)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (WrongOperationException ex)
            {
                return this.StatusCode(StatusCodes.Status412PreconditionFailed, ex.Message);
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }
    }
}