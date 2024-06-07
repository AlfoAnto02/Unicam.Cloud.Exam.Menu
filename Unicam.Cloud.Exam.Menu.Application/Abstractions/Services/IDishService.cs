using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Application.Abstractions.Services {
    public interface IDishService : GeneralService<Dish>{

        Task<IEnumerable<Dish>> GetByTypologyIdAsync(int typeId);

        Task<IEnumerable<Dish>> GetByTypologyAsync(string typology);

        Task<IEnumerable<Dish>> GetWithPriceGreatherThanAsync(double price);

        Task<IEnumerable<Dish>> GetWithPriceLessThanAsync(double price);
    }
}
