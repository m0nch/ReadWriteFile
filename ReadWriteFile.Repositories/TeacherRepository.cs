using ReadWriteFile.Data.DB;
using ReadWriteFile.Data.Models;
using System;
using System.Data;

namespace ReadWriteFile.Repositories
{
    internal class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        private readonly IDbContext _dbContext;
        public TeacherRepository(IDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override void Add(Teacher model)
        {
            _dbContext.LastName = model.LastName;
            _dbContext.FirstName = model.FirstName;
            _dbContext.Age = model.Age;
            _dbContext.Id = model.Id;
            _dbContext.Write(_dbContext.TxtTeachers);
        }
        public override Teacher Get(Guid id)
        {
            _dbContext.Read(id, _dbContext.TxtTeachers);
            Teacher teacher = new Teacher
            {
                LastName = _dbContext.LastName,
                FirstName = _dbContext.FirstName,
                Age = _dbContext.Age,
                Id = id
            };
            return teacher;
        }
        public override DataTable GetAll()
        {
            return _dbContext.Read(_dbContext.TxtTeachers);
        }
        public override void Remove(Teacher model)
        {
            _dbContext.Replace(_dbContext.Find(model.Id.ToString(), _dbContext.TxtTeachers), null, _dbContext.TxtTeachers);
        }
        public override void Update(Teacher model)
        {
            _dbContext.Replace(_dbContext.Find(model.Id.ToString(), _dbContext.TxtTeachers), null, _dbContext.TxtTeachers);
            Add(model);
        }
    }
}
