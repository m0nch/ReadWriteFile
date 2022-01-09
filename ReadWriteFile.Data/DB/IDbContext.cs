using System;
using System.Data;

namespace ReadWriteFile.Data.DB
{
    public interface IDbContext
    {
        string LastName { get; set; }
        string FirstName { get; set; }
        int Age { get; set; }
        Guid Id { get; set; }
        Guid TeacherId { get; set; }
        string TxtTeachers { get; set; }
        string TxtStudents { get; set; }
        string TxtTemp { get; set; }
        void Write(string txt);
        DataTable Read(string txt);
        DataTable Read(Guid id, string txt);
        string Find(string txt, string file);
        void Replace(string lineRemove, string lineInsert, string file);
    }
}
