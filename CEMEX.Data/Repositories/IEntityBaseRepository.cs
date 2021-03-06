﻿using CEMEX.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;
using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Repositories
{
    public interface IEntityBaseRepository<T> where T: class, IEntidadBase, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T,object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        T GetSingle(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
