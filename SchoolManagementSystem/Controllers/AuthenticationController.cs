using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.ApplicationUsers;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.Components;
using SchoolManagementSystem.Repositories.Authentication;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationController( IAuthenticationRepository authenticationRepository, UserManager<ApplicationUser> userManager)
        {
            _authenticationRepository = authenticationRepository;
            _userManager = userManager;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromBody] SignUp? signUp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response<object>(false, "Validation Failed", ModelState));
            }
            try
            {


                var Result = await _authenticationRepository.SignUpAsync(signUp!);

                if (Result.Succeeded == false)
                {
                    return BadRequest(Result);
                }

  
                return Ok(new Response<object>(Result.Succeeded, Result.Message!));
            }
            catch (Exception ex)
            {

                return Unauthorized(new Response<object>(false, ex.Message, ex.Data));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignIn signIn)
        {
            var result = await _authenticationRepository.LoginAsync(signIn);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }

        [HttpGet("user")]
        public async Task<IActionResult> CurrentUser()
        {
            var email = HttpContext.User?.Claims.First().Value;
            if (email == null) return Unauthorized("Not a Valid Token");
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return NotFound("user not found");
            var role = await _userManager.GetRolesAsync(user);
            return Ok(

                new Response<object>(true, "The current user",
                new
                {
                    user.FullName,
                    user.Email,
                    user.Id,
                    role,
                    user.PhoneNumber,

                }));
        }

    }
}
