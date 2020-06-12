using DotNetExerciseAPI.Dtos;
using DotNetExerciseAPI.Models;
using AutoMapper;

namespace DotNetExerciseAPI.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentCreateDto, Student>();
        }
    }
}
