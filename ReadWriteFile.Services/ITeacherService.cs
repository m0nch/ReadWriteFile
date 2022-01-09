using ReadWriteFile.Data.Models;
using System;
using System.Data;

namespace ReadWriteFile.Services
{
    public interface ITeacherService
    {
        void Add(Teacher model);
        void Remove(Teacher model);
        void Update(Teacher model);
        Teacher Get(Guid id);
        DataTable GetAll();
    }
}
