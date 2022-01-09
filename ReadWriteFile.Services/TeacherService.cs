using ReadWriteFile.Data.Models;
using ReadWriteFile.Repositories;
using System;
using System.Data;

namespace ReadWriteFile.Services
{
    internal class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public void Add(Teacher model)
        {
            _teacherRepository.Add(model);
        }
        public Teacher Get(Guid id)
        {
            return _teacherRepository.Get(id);
        }
        public DataTable GetAll()
        {
            return _teacherRepository.GetAll();
        }
        public void Remove(Teacher model)
        {
            _teacherRepository.Remove(model);
        }
        public void Update(Teacher model) 
        {
            _teacherRepository.Update(model);
        }
    }
}
