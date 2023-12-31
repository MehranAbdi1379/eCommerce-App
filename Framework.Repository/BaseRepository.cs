﻿using Framework.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity 
    {
        protected readonly DataBaseContext context;

        public BaseRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public TEntity GetById(Guid id)
        {
            return context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public bool IsExist(Guid id)
        {
            return context.Set<TEntity>().Any(x => x.Id == id);
        }
    }
}
