using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Application.Abstractions.Services;
using Unicam.Cloud.Exam.Menu.Models.Entities;
using Unicam.Cloud.Exam.Menu.Models.Repositories;

namespace Unicam.Cloud.Exam.Menu.Application.Services {
    public class DishService : IDishService {
        public readonly DishRepository dishRepository;

        public DishService(DishRepository dishRepository) {
            this.dishRepository = dishRepository;
        }

        public async Task AddAsync(Dish entity) {
            dishRepository.Add(entity);
            await dishRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) {
            dishRepository.Delete(await GetByIdAsync(id));
            await dishRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dish>> GetAllAsync() {
            var dishes = await dishRepository.GetAllAsync();
            if (dishes.Count() == 0) throw new Exception("No dishes Found");
            return dishes;
        }

        public async Task<Dish> GetByIdAsync(int id) {
            var dish = await dishRepository.GetByIdAsync(id);
            if (dish == null) throw new Exception("Dish id isn't registered");
            return dish;
        }

        public async Task UpdateAsync(int id, Dish entity) {
            var dishToUpdate = await GetByIdAsync(id);
            dishToUpdate.Name = entity.Name;
            dishToUpdate.Price = entity.Price;
            dishToUpdate.TypeId = entity.TypeId;
            dishRepository.Update(dishToUpdate);
            await dishRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Dish>> GetByTypologyIdAsync(int typeId) {
            var dishes = await dishRepository.GetByTypologyIdAsync(typeId);
            if (dishes.Count() == 0) throw new Exception("No Dishes found with that Typology");
            return dishes;
        }

        public async Task<IEnumerable<Dish>> GetByTypologyAsync(string typology) {
            var dishes = await dishRepository.GetByTypologyAsync(typology);
            if(dishes.Count() == 0) throw new Exception("No Dishes found with that Typology");
            return dishes;
        }

        public async Task<IEnumerable<Dish>> GetWithPriceGreatherThanAsync(double price) {
            var dishes = await dishRepository.GetWithPriceGreatherThanAsync(price);
            if (dishes.Count() == 0) throw new Exception($"No Dishes Found with price greather than {price}");
            return dishes;
        }

        public async Task<IEnumerable<Dish>> GetWithPriceLessThanAsync(double price) {
            var dishes = await dishRepository.GetWithPriceLessThanAsync(price);
            if (dishes.Count() == 0) throw new Exception($"No dishes Found with price lower than {price}");
            return dishes;
        }

    }
}
