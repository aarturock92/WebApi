﻿using CEMEX.Data.Infrastructure;
using CEMEX.Entidades;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace CEMEX.Data.Repositories
{
    public class EntityBaseRepository<T>: IEntityBaseRepository<T> where T: class,IEntidadBase, new()
    {
        private CemexContext dataContext;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected CemexContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        public EntityBaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x =>x.ID == id);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
        }

        public virtual void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }
    }
}
