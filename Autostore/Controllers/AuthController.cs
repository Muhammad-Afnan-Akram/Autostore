using Autostore.Services;
using Autostore.Model;
using Microsoft.AspNetCore.Mvc;
using Autostore.ExceptionHandling;
using System.Security.Authentication;

namespace AuthDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(LoginUser user)
        {
            try
            {
                ValidateUserDataAndPassword(user);
                if (await _authService.RegisterUser(user))
                {
                    return Ok("User Register Successfully");
                }
                return BadRequest("Something went wrong during registration.");
            }
            catch (InvalidUserDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RoleAssignmentException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (InvalidPasswordException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                if (await _authService.Login(user))
                {
                    var tokenString = _authService.GenerateTokenString(user);
                    return Ok(tokenString);
                }
                return BadRequest("Authentication failed. Email or Password not match");
            }
            catch (AuthenticationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private void ValidateUserDataAndPassword(LoginUser user)
        {

            if (!IsValidEmail(user.Email))
            {
                throw new InvalidUserDataException("Invalid email format.");//
            }

            if (!IsValidPassword(user.Password))
            {
                throw new InvalidPasswordException("Invalid password format.");//
            }

            if (!IsAllowedRole(user.Role))
            {
                throw new RoleAssignmentException("Invalid role assignment. Choose from: Cashier, Seller, Accountant.");
            }
        }

        private bool IsValidEmail(string email)
        {

            return !string.IsNullOrWhiteSpace(email) && email.Contains("@");
        }

        private bool IsValidPassword(string password)
        {

            return !string.IsNullOrEmpty(password) && password.Length >= 8;
        }

        private bool IsAllowedRole(string role)
        {
            string[] allowedRoles = { "Cashier", "Seller", "Accountant" };
            return allowedRoles.Contains(role);
        }
    }
}