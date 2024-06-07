using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Models.Context;

namespace Unicam.Cloud.Exam.Menu.Models.Repositories {
    public abstract class GenericRepository <T> where T: class{
        public readonly MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx) {
            _ctx = ctx;
        }

        public async Task<List<T>> GetAllAsync() {
            return await _ctx.Set<T>().ToListAsync();
        }

        public void Add(T entity) {
            _ctx.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity) {
            _ctx.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity) {
            _ctx.Entry(entity).State = EntityState.Deleted;
        }

        public async Task SaveChangesAsync() {
            await _ctx.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id) {
            return await _ctx.Set<T>().FindAsync(id);
        }
    }
}
