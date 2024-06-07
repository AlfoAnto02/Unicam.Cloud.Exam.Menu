using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Application.Models.Requests {
    public class DishTypeAddRequest {
        public string Typology { get; set; }

        public DishType ToEntity() { 
            return new DishType {
                Typology = Typology
            };
        }
    }
}
