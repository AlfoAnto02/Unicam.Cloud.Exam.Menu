using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Context;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Models.Repositories {
    public class DishTypeRepository : GenericRepository<DishType> {
        public DishTypeRepository(MyDbContext ctx) : base(ctx) { }
        public async Task<DishType> GetByTypologyAsync(string typology) {
            return await _ctx.DishTypes.FirstOrDefaultAsync(x => x.Typology == typology);
        }

        public async Task<bool> ExistByNameAsync(string name) {
            return  await _ctx.DishTypes.AnyAsync(x => x.Typology == name);
        }

        
    }
}
