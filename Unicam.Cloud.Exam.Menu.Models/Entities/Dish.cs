using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Unicam.Cloud.Exam.Menu.Models.Entities {
    public class Dish {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int TypeId { get; set; }
        public virtual DishType Type { get; set; }
    }
}
