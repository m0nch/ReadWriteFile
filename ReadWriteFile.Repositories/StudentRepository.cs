using ReadWriteFile.Data.DB;
using ReadWriteFile.Data.Models;
using System;
using System.Data;

namespace ReadWriteFile.Repositories
{
    internal class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly IDbContext _dbContext;
        public StudentRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override void Add(Student model)
        {
            _dbContext.LastName = model.LastName;
            _dbContext.FirstName = model.FirstName;
            _dbContext.Age = model.Age;
            _dbContext.Id = model.Id;
            _dbContext.TeacherId = model.TeacherId;
            _dbContext.Write(_dbContext.TxtStudents);
        }
        public override Student Get(Guid id)
        {
            _dbContext.Read(id, _dbContext.TxtStudents);
            Student student = new Student
            {
                LastName = _dbContext.LastName,
                FirstName = _dbContext.FirstName,
                Age = _dbContext.Age,
                Id = id,
                TeacherId = _dbContext.TeacherId
            };
            return student;
        }
        public override DataTable GetAll()
        {
            return _dbContext.Read(_dbContext.TxtStudents);
        }
        public override void Remove(Student model)
        {
            _dbContext.Replace(_dbContext.Find(model.Id.ToString(), _dbContext.TxtStudents), null, _dbContext.TxtStudents);
        }
        public DataTable GetAllByTeacher(Guid id)
        {
            return _dbContext.Read(id, _dbContext.TxtStudents);
        }
        public override void Update(Student model)
        {
            _dbContext.Replace(_dbContext.Find(model.Id.ToString(), _dbContext.TxtStudents), null, _dbContext.TxtStudents);
            Add(model);
        }
    }
}
