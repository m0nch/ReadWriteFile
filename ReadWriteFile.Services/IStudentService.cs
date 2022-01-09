using ReadWriteFile.Data.Models;
using System;
using System.Data;

namespace ReadWriteFile.Services
{
    public interface IStudentService
    {
        void Add(Student model);
        void Remove(Student model);
        void Update(Student model);
        Student Get(Guid id);
        DataTable GetAll();
        DataTable GetAllByTeacher(Guid id);
    }
}
