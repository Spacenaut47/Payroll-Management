using Microsoft.AspNetCore.Mvc;
using PayrollManagement.Core.DTOs.Auth;
using PayrollManagement.Core.Entities;
using PayrollManagement.Core.Interfaces;
using PayrollManagement.Core.Common;

namespace PayrollManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IPasswordService _passwordService;
        private readonly IJwtTokenService _jwt;

        public AuthController(IUnitOfWork uow, IPasswordService passwordService, IJwtTokenService jwt)
        {
            _uow = uow;
            _passwordService = passwordService;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<string>>> Register([FromBody] RegisterRequestDto dto)
        {
            var existing = await _uow.Users.GetByUsernameAsync(dto.Username);
            if (existing != null)
            {
                return BadRequest(new ApiResponse<string> { Success = false, Error = "Username already exists" });
            }

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = _passwordService.HashPassword(dto.Password),
                FullName = dto.FullName,
                Email = dto.Email
            };

            await _uow.Users.AddAsync(user);
            await _uow.CommitAsync();

            return Ok(new ApiResponse<string> { Data = "User created" });
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResponseDto>>> Login([FromBody] LoginRequestDto dto)
        {
            var user = await _uow.Users.GetByUsernameAsync(dto.Username);
            if (user == null || !_passwordService.VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized(new ApiResponse<LoginResponseDto> { Success = false, Error = "Invalid credentials" });

            var token = _jwt.GenerateToken(user);

            var res = new LoginResponseDto
            {
                Token = token,
                Username = user.Username,
                FullName = user.FullName,
                Role = user.Role.ToString()
            };

            return Ok(new ApiResponse<LoginResponseDto> { Data = res });
        }
    }
}
