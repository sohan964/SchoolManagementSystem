using SchoolManagementSystem.Models.Components;
using SchoolManagementSystem.Models.Dtos.ParentDtos;
using SchoolManagementSystem.Models.Dtos.StudentDtos;
using SchoolManagementSystem.Models.Dtos.TeacherDtos;

namespace SchoolManagementSystem.Repositories.ProfileRepositories
{
    public interface IProfileRepository
    {
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task<object> AddStudentAsync(CreateStudentDto student);
        Task<ParentDto> GetParentByIdAsync(int id);
        Task<TeacherDto> GetTeacherByIdAsync(int id);
        Task<object> AddParentAsync(CreateParentDto parent);


    }
}
