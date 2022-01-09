using System;

namespace ReadWriteFile.Data.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
