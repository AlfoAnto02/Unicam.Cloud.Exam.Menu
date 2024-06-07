using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Application.Models.Requests {
    public class DishAddRequest {
        public string Name { get; set; }
        public double Price { get; set; }
        public int TypeID { get; set; }

        public Dish ToEntity(){
            return new Dish {
                Name = Name,
                Price = Price,
                TypeId = TypeID
            };
        }
    }
}
