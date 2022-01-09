using System;
using System.Data;

namespace ReadWriteFile.Repositories
{
    public interface IBaseRepository<T>
    {
        void Add(T model);
        void Remove(T model);
        void Update(T model);
        T Get(Guid id);
        DataTable GetAll();
    }
}
