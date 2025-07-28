using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.Components;

namespace SchoolManagementSystem.Repositories.Authentication
{
    public interface IAuthenticationRepository
    {
        Task<Response<object>> SignUpAsync(SignUp signUp);
        Task<Response<object>> LoginAsync(SignIn signIn);
    }
}
