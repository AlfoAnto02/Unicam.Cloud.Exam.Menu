using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Cloud.Exam.Menu.Models.Entities {
    public class DishType {
        public int Id { get; set; }
        public string Typology { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
