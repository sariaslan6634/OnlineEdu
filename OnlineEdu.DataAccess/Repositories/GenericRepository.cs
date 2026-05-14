using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineEdu.DataAccess.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly OnlineEduContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(OnlineEduContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<int> CountAsync()
        {
            return await _table.CountAsync();
        }

        public async Task CreateAsync(T entity)
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity =await _table.FindAsync(id);
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> FilteredCountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).CountAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
