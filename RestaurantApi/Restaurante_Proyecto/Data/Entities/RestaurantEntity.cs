using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante_Proyecto.Data.Entities
{
    public class RestaurantEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string FoodStyle { get; set; }
        [Required]
        public string Street { get; set; }
        public int AddressNumber { get; set; }
        public ICollection<DishEntity> Dishes { get; set; }
    }
}
