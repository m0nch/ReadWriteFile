using ReadWriteFile.Data.Models;
using ReadWriteFile.Repositories;
using System;
using System.Data;

namespace ReadWriteFile.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void Add(Student model)
        {
            _studentRepository.Add(model);
        }
        public Student Get(Guid id)
        {
            return _studentRepository.Get(id);
        }
        public DataTable GetAll()
        {
            return _studentRepository.GetAll();
        }
        public DataTable GetAllByTeacher(Guid id)
        {
            return _studentRepository.GetAllByTeacher(id);
        }
        public void Remove(Student model)
        {
            _studentRepository.Remove(model);
        }
        public void Update(Student model)
        {
            _studentRepository.Update(model);
        }
    }
}
