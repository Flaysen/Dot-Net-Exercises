using DotNetExerciseAPI.Models;
using System.Collections.Generic;

namespace DotNetExerciseAPI.Data
{
    public interface IStudentRepository
    {
        bool SaveChanges();

        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteCommand(Student student);
    }
}
