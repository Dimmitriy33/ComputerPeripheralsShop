using ComputerPeripheralsShop.Models.DataAccess.interfaces.@base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ComputerPeripheralsShop.Models.DataAccess.repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T item) => _context.Set<T>().Add(item);

        public void AddRange(IEnumerable<T> items) => _context.Set<T>().AddRange(items);

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => _context.Set<T>().Where(predicate);

        public T Get(int id) => _context.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();

        public void Remove(T items) => _context.Set<T>().Remove(items);

        public void RemoveRange(IEnumerable<T> items) => _context.Set<T>().RemoveRange(items);
    }
}
