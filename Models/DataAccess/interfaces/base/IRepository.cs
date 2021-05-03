using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ComputerPeripheralsShop.Models.DataAccess.interfaces.@base
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void AddRange(IEnumerable<T> items);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Remove(T items);
        void RemoveRange(IEnumerable<T> items);
    }
}
