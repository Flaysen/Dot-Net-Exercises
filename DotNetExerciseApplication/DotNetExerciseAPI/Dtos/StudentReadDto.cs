using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetExerciseAPI.Dtos
{
    public class StudentReadDto
    { 
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required!")]
        [StringLength(30, ErrorMessage = "First name is too long!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(30, ErrorMessage = "Last name is too long!")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Index is required!")]
        [Range(100000, 999999, ErrorMessage = "It's not valid error massage!")]
        public int Index { get; set; }
    }
}
