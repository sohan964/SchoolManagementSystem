using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models.Components;
using SchoolManagementSystem.Models.Dtos.ParentDtos;
using SchoolManagementSystem.Models.Dtos.StudentDtos;
using SchoolManagementSystem.Repositories.ProfileRepositories;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }


        //about Studnets

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetStudentById( [FromRoute]int id)
        {
            var student = await  _profileRepository.GetStudentByIdAsync(id);
            if(student == null ) return NotFound( new Response<object> (false, "not found the student"));

            return Ok(new Response<object> (true, "Student found", student));
        }

        [HttpPost("student/AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentDto student)
        {
            var newStudent = await _profileRepository.AddStudentAsync(student);
            if(newStudent == null) return BadRequest(new Response<object>(false, "fail to add student", newStudent));
            return Ok(new Response<object>(true, "Student Added success", newStudent));
        }


        //about parents

        [HttpGet("parent/{id}")]
        public async Task<IActionResult> GetParentById([FromRoute] int id)
        {
            var parent = await _profileRepository.GetParentByIdAsync(id);
            if (parent == null) return NotFound(new Response<object>(false, "Parent Not Found"));
            return Ok(new Response<object>(true, "Parent Details", parent));
        }

        [HttpPost("parent/addparent")]
        public async Task<IActionResult> AddParent([FromBody] CreateParentDto parent)
        {
            var newParent = await _profileRepository.AddParentAsync(parent);
            if(parent == null) return BadRequest(new Response<object>(false, "Fail to add Parent", newParent));
            return Ok(new Response<object>(true, "Added Success", newParent));
        }




        //about Teacher

        [HttpGet("teacher/{id}")]
        public async Task<IActionResult> GetTeacherById([FromRoute]int id)
        {
            var teacher = await _profileRepository.GetTeacherByIdAsync(id);
            if (teacher == null) return NotFound(new Response<object> (false, "Not found"));
            return Ok(new Response<object>(true, "Teacher Details", teacher));
            
        }
    }
}
