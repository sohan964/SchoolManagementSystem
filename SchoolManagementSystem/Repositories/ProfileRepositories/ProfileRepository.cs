using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Data.AcademicStructure;
using SchoolManagementSystem.Data.ApplicationUsers.UserProfiles;
using SchoolManagementSystem.Models.Components;
using SchoolManagementSystem.Models.Dtos.ParentDtos;
using SchoolManagementSystem.Models.Dtos.StudentDtos;
using SchoolManagementSystem.Models.Dtos.TeacherDtos;
using Stripe;
using System.Diagnostics.Metrics;

namespace SchoolManagementSystem.Repositories.ProfileRepositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        //for Student
        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.Where(x => x.Id == id).Select(st => new StudentDto
            {
               FullName = st.User.FullName,
               UserName = st.User.UserName,
               Email = st.User.Email,

               ParentEmail = st.Parent.User.Email,
               ParentName = st.Parent.User.FullName,

               DOB = st.DOB,
               Gender = st.Gender,
               BloodGroup = st.BloodGroup,
               PhotoUrl = st.PhotoUrl,
               Address = st.Address,
               City = st.City,
               Region = st.Region,
               PostalCode = st.PostalCode,
               Country = st.Country,
               Status  = st.Status,
               DepartmentName = _context.StudentDepartments.Where(x => x.StudentId == id && x.EndDate == null).Select(x => x.Department.Name).SingleOrDefault(),

            }).FirstOrDefaultAsync();

            return student!;
        }

        public async Task<object> AddStudentAsync(CreateStudentDto student)
        {
            

            var newStudent = new Student()
            {
               DOB = student.DOB,
               Gender = student.Gender,
               BloodGroup = student.BloodGroup,
               PhotoUrl = student.PhotoUrl,
               Address = student.Address,
               City = student.City,
               Region = student.Region,
               PostalCode = student.PostalCode,
               Country = student.Country,
               Status = student.Status,

               ParentId = student.ParentId,
               UserId = student.UserId,
               CreatedAt = DateTime.UtcNow,
               UpdatedAt = DateTime.UtcNow,

            };

            
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();
            var department = new StudentDepartment()
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                StudentId = newStudent.Id,
                DepartmentId = (int)student.DepartmentId,
                StartDate = DateOnly.MaxValue,
            };
            await _context.StudentDepartments.AddAsync(department);
            var result = await _context.SaveChangesAsync();
            return result;
        }


        //for Parent
        public async Task<ParentDto> GetParentByIdAsync(int id)
        {
            var parent = await _context.Parents.Where(x => x.Id == id).Select( pt => new ParentDto
            {
                FullName = pt.User.FullName,
                Email = pt.User.Email,
            }).FirstOrDefaultAsync();

            return parent!;
        }

         //add Parents
        public async Task<object> AddParentAsync( CreateParentDto parent)
        {
            var newParent = new Parent()
            {
                Address = parent.Address,
                UserId = parent.UserId,

            };

            await _context.Parents.AddAsync(newParent);
            var res = await _context.SaveChangesAsync();
            return res;
        }

        // for Teacher
        public async Task<TeacherDto> GetTeacherByIdAsync(int id)
        {
            var teacher = await _context.Teachers.Where(x => x.Id == id).Select(t => new TeacherDto
            {
                FullName = t.User.FullName,
                Email = t.User.Email,
                DepartmentName = t.Department.Name,
                Status = t.Status,
                Designation = t.Designation,
                PhotoUrl = t.PhotoUrl,
            }).FirstOrDefaultAsync();

            return teacher!;
        }


    }
}