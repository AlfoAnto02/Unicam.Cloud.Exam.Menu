using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Application.Abstractions.Services {
    public interface IDishTypeService : GeneralService<DishType>{
        Task AddDishToTipologyAsync(int dishTypeId, int dishId);
    }
}
