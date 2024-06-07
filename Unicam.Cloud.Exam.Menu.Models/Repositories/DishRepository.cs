using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Context;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Models.Repositories {
    public class DishRepository : GenericRepository<Dish> {
        public DishRepository(MyDbContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Dish>> GetByTypologyAsync(string typology) {
            return await _ctx.Dishes.Where(d => d.Type.Typology.ToLower() == typology.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetByTypologyIdAsync(int typologyId) {
            return await _ctx.Dishes.Where(d => d.Type.Id == typologyId).ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetWithPriceGreatherThanAsync(double price) {
            return await _ctx.Dishes.Where(d => d.Price > price)
                .OrderBy(d => d.Price)
                .ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetWithPriceLessThanAsync(double price) {
            return await _ctx.Dishes.Where(d => d.Price < price)
                .OrderBy(d => d.Price)
                .ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetByName(string name) {
            return await _ctx.Dishes.Where(d => d.Name.ToLower() == name.ToLower()).ToListAsync();
        }

    }
}
