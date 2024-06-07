using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Application.Models.Requests {
    public class DishUpdateRequest {
        public int DishId { get; set; }
        public DishAddRequest Dish { get; set; }
    }
}
