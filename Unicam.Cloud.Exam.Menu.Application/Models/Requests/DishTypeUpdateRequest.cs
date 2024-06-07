using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Cloud.Exam.Menu.Application.Models.Requests {
    public class DishTypeUpdateRequest {
        public int DishTypeId { get; set; }
        public DishTypeAddRequest DishType { get; set; }
    }
}
