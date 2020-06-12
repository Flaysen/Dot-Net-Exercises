using System.Collections.Generic;
using AutoMapper;
using DotNetExerciseAPI.Data;
using DotNetExerciseAPI.Dtos;
using DotNetExerciseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetExerciseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        private readonly IMapper _mapper;

        //private readonly MockStudentsRepository _repository = new MockStudentsRepository();

        public StudentsController(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllCommands()
        {
            var students = _repository.GetStudents();

            return Ok(students);
        }

        [HttpGet("{id}", Name= "GetStudentById")]
        public ActionResult<StudentReadDto> GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);

            if (student != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(student));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<StudentReadDto> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var studentModel = _mapper.Map<Student>(studentCreateDto);
            _repository.CreateStudent(studentModel);
            _repository.SaveChanges();

            var studentReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return CreatedAtRoute(nameof(GetStudentById), new { id = studentReadDto.Id }, studentCreateDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentCreateDto studentCreateDto)
        {
            var student = _repository.GetStudentById(id);
            if(student == null)
            {
                return NotFound();
            }

            _mapper.Map(studentCreateDto, student);

            _repository.UpdateStudent(student);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(student);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
