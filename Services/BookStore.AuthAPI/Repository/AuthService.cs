using BookStore.AuthAPI.Data;
using BookStore.AuthAPI.Models;
using BookStore.AuthAPI.Models.Dto;
using BookStore.AuthAPI.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.AuthAPI.Repository
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //injecting the token generator
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string rolename)
        {
            //retrive user based on email
            var user = await _db.ApplicationUsers.FirstOrDefaultAsync(a => a.Email == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(rolename).GetAwaiter().GetResult())
                {
                    //Create role if it does not exist
                    _roleManager.CreateAsync(new IdentityRole(rolename)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, rolename);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            //retrieve the user from database
            var user = await _db.ApplicationUsers.FirstOrDefaultAsync(a => a.UserName.ToLower() == loginRequestDto.Username.ToLower());
            //Check the validity of the password
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            //If user is not found
            if (user == null || isValid == false)
            {
                return new LoginResponseDto()
                {
                    User = null,
                    Token = ""
                };
            }
            //If user was found, generate JWT Token
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);
            UserDto userDto = new UserDto()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };
            return loginResponseDto;
        }

        public async Task<string> Register(RegisterationRequestDto registerationRequestDto)
        {
            //Getting a new user by mapping it to the registerationrequestdto
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerationRequestDto.Email,
                Email = registerationRequestDto.Email,
                NormalizedEmail = registerationRequestDto.Email.ToUpper(),
                Name = registerationRequestDto.Name,
                PhoneNumber = registerationRequestDto.PhoneNumber
            };

            //The functionality that creates the registeration for the user
            try
            {
                var result = await _userManager.CreateAsync(user, registerationRequestDto.Password);//IdentityUser creates the hashing automatic
                if (result.Succeeded)//returns the user that is created
                {
                    var userToReturn = _db.ApplicationUsers.First(a => a.UserName == registerationRequestDto.Email);
                    UserDto userDto = new UserDto()
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            //If there is an error, return userdto without any details
            return "Error encountered during registeration";

        }
    }
}
