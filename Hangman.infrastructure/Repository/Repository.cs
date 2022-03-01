using Hangman.Data;
using Hangman.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly HangmanContext _Context;
        private DbSet<T> entities;
        public Repository(HangmanContext context)
        {
            _Context = context;
            entities = context.Set<T>();
        }
        public async Task<IAsyncEnumerable<T>> GetAllAsync()
        {
            return entities.AsAsyncEnumerable();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await entities.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity cannot be null");
            }
            await entities.AddAsync(entity).AsTask();
            await _Context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity cannot be null");
            }
            await _Context.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            T entity = await entities.SingleOrDefaultAsync(s => s.Id == id);
            entities.Remove(entity);
            await _Context.SaveChangesAsync();
        }
    }
}
