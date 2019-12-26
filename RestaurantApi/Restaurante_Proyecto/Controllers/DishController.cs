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
    [Route("api/Restaurant/{restaurantId:int}/Dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private IDishService dishService;
        public DishController(IDishService dishService)
        {
            this.dishService = dishService;
        }
        // GET: api/Dish
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes(int restaurantId)
        {
            try
            {
                return Ok(await dishService.GetDishesAsync(restaurantId));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Dish>> GetDish(int id, int restaurantId)
        {
            try
            {
                return Ok(await dishService.GetDishAsync(restaurantId,id));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Dish>> Post([FromBody] Dish dish, int restaurantId)
        {
            try
            {
                return Ok(await dishService.CreateDishAsync(restaurantId, dish));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Dish>> PutDish(int id, [FromBody] Dish dish, int restaurantId)
        {
            try
            {
                return Ok(await dishService.UpdateDishAsync(restaurantId, id, dish));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteDish(int id, int restaurantId)
        {
            try
            {
                return Ok(await dishService.DeleteDish(restaurantId, id));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }
    }
}
