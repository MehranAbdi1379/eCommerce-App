﻿using Framework.Core.Domain;

namespace Framework.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Save();
        void Update(TEntity entity);
        TEntity GetById(Guid id);  
        bool IsExist(Guid id);
        public List<TEntity> GetAll();
    }
}