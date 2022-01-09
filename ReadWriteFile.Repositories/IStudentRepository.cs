using ReadWriteFile.Data.Models;
using System;
using System.Data;

namespace ReadWriteFile.Repositories
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        DataTable GetAllByTeacher(Guid id);
    }
}
