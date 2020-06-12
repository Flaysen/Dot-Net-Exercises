using DotNetExerciseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetExerciseAPI.Data
{
    public class SqlStudentsRepository : IStudentRepository
    {

        private readonly StudentContext _context;

        public SqlStudentsRepository(StudentContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
           if(student == null)
           {
                throw new ArgumentNullException(nameof(student));
           }

            _context.Students.Add(student);
        }

        public void DeleteCommand(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Remove(student);
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Where(x => x.Id == id).FirstOrDefault();
        }   

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateStudent(Student student) { }

    }
}
