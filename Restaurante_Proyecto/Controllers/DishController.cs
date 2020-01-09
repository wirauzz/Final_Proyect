using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante_Proyecto.Exceptions;
using Restaurante_Proyecto.Models;
using Restaurante_Proyecto.Services;

namespace Restaurante_Proyecto.Controllers
{
    [Route("api/Restaurant/{restaurantId:int}/Dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private IDishService dishService;
        public DishController(IDishService dishService)
        {
            this.dishService = dishService;
        }
        
        // GET: api/Restaurant/1/Dish
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes(int restaurantId)
        {
            try
            {
                var dishesFromRestaurant = await dishService.GetDishesAsync(restaurantId);
                if (!dishesFromRestaurant.Any())
                    return BadRequest("No dishes have been registrated for this restaurant");
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Dish>> GetDish(int id, int restaurantId)
        {
            try
            {
                return Ok(await dishService.GetDishAsync(restaurantId,id));
            }
            catch (NotFoundItemException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch
            {
                throw new Exception("Dish was not found");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Dish>> PostDish([FromBody] Dish dish, int restaurantId)
        {
            try
            {
                var dishCreated = await dishService.CreateDishAsync(restaurantId, dish);
                return Created($"api/Restaurant/{restaurantId}/Dish/{dishCreated.Id}",dishCreated);
            }
            catch (WrongOperationException ex)
            {
                return this.StatusCode(StatusCodes.Status412PreconditionFailed, ex.Message);
            }
            catch (ChangesNotExecutedException ex)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Dish>> PutDish(int id, [FromBody] Dish dish, int restaurantId)
        {
            try
            {
                return Ok(await dishService.UpdateDishAsync(restaurantId, id, dish));
            }
            catch (WrongOperationException ex)
            {
                return this.StatusCode(StatusCodes.Status412PreconditionFailed, ex.Message);
            }
            catch (NotFoundItemException ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ChangesNotExecutedException ex)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteDish(int id, int restaurantId)
        {
            try
            {
                if(await dishService.DeleteDish(restaurantId, id))
                {
                    return this.StatusCode(StatusCodes.Status410Gone, "Dish deleted");
                }
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Dish not deleted");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
