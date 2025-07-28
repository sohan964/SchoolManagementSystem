
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Data.ApplicationUsers;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.Components;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagementSystem.Repositories.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticationRepository( UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<Response<object>> SignUpAsync(SignUp signUp)
        {
            var user = new ApplicationUser()
            {
                FullName = signUp.FullName,
                Email = signUp.Email,
                UserName = signUp.Email,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, signUp.Password!);

            if (await _roleManager.RoleExistsAsync("User"))
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            if (result.Succeeded)
            {
                return new Response<object>(true, "Successfully SignUp", new {  email = user.Email });
            }

            return new Response<object>(false, "SignUp failed", result.Errors);


        }

        public async Task<Response<object>> LoginAsync(SignIn signIn)
        {
            var user = await _userManager.FindByEmailAsync(signIn.Email!);
            if (user == null) return new Response<object>(false, "User not found");
            if (!await _userManager.CheckPasswordAsync(user, signIn.Password!))
            {
                return new Response<object>(false, "Wrong Password");
            }
           

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            //foreach (var role in userRoles)
            //{
            //    authClaims.Add(new Claim(ClaimTypes.Role, role));
            //}

            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));


            //GetToken private generate at the bottom
            var jwtToken = GetToken(authClaims);

            return new Response<object>(

                true,
                "Login Success",
                new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                }
            );


        }


        //Jwt Token Generate
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

    }
}
