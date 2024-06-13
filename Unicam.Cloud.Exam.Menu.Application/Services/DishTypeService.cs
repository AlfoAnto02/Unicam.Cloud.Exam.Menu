using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Application.Abstractions.Services;
using Unicam.Cloud.Exam.Menu.Models.Entities;
using Unicam.Cloud.Exam.Menu.Models.Repositories;

namespace Unicam.Cloud.Exam.Menu.Application.Services {
    public class DishTypeService : IDishTypeService{
        public readonly DishTypeRepository dishTypeRepository;
        public readonly DishRepository dishRepository;
        public DishTypeService(DishTypeRepository dishTypeRepository, DishRepository dishRepository) {
            this.dishTypeRepository = dishTypeRepository;
            this.dishRepository = dishRepository;
        }

        public async Task AddAsync(DishType entity) {
            dishTypeRepository.Add(entity);
            await dishTypeRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) {
            var dishType = await GetByIdAsync(id);
            if(dishType==null) {
                throw new InvalidOperationException("Dish type not found");
            }
            if(dishType.Dishes.Count > 0) {
                throw new InvalidOperationException("Cannot delete a dish type with associated dishes");
            }
            dishTypeRepository.Delete(dishType);
            await dishTypeRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<DishType>> GetAllAsync() {
            var dishTypes = await dishTypeRepository.GetAllAsync();
            if(dishTypes.Count() == 0) {
                throw new InvalidOperationException("No dish types found");
            }
            return dishTypes;
        }

        public async Task<DishType> GetByIdAsync(int id) {
            var dishType = await dishTypeRepository.GetByIdAsync(id);
            if(dishType == null) {
                throw new InvalidOperationException("Dish type not found");
            }
            return dishType;
        }

        public async Task UpdateAsync(int id, DishType entity) {
            var dishTypeToUpdate = await GetByIdAsync(id);
            dishTypeToUpdate.Typology = entity.Typology;
            dishTypeRepository.Update(dishTypeToUpdate);
            await dishTypeRepository.SaveChangesAsync();
        }

        public async Task AddDishToTipologyAsync(int dishTypeId, int dishId) {
            var dishType = await GetByIdAsync(dishTypeId);
            var dish = await dishRepository.GetByIdAsync(dishId);
            dishType.Dishes.Add(dish);
            await dishTypeRepository.SaveChangesAsync();
        }
    }
}
