using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Application.Models.DTOs {
    public class DishTypeDTO {
        public int Id { get; set; }
        public string Typology { get; set; }

        public DishTypeDTO(DishType dishType){
            Id = dishType.Id;
            Typology = dishType.Typology;
        }
    }
}
