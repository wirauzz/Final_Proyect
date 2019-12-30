using Microsoft.AspNetCore.Mvc;
using Restaurante_Proyecto.Models;
using Restaurante_Proyecto.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesAllController :ControllerBase
    {
        private IDishService dishService;
        public DishesAllController(IDishService dishService)
        {
            this.dishService = dishService;
        }
        //GET: api/DishesAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetAllDishes()
        {
            try
            {
                return Ok(await dishService.GetAllDishesAsync());
            }
            catch
            {
                return BadRequest("There was a problem with the data base");
            }
        }
    }
}
