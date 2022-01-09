using ReadWriteFile.Data.DB;
using System;
using System.Data;

namespace ReadWriteFile.Repositories
{
    internal class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly IDbContext _dbContext;
        public BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual void Add(T model)
        {
            throw new NotImplementedException();
        }
        public virtual T Get(Guid id)
        {
            throw new NotImplementedException();
        }
        public virtual DataTable GetAll()
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(T model)
        {
            throw new NotImplementedException();
        }
        public virtual void Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
