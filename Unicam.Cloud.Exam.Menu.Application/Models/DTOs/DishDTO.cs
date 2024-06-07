using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Application.Models.DTOs {
    public class DishDTO {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Typology { get; set; }

        public DishDTO(Dish dish) {
            ID = dish.Id;
            Name = dish.Name;
            Price = dish.Price;
            Typology = dish.Type.Typology;
        }
    }
}
