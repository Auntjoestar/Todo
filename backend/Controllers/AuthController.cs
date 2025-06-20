using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/")]
    public class Auth : ControllerBase
    {
        [HttpGet("me")]
        public IActionResult Me()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return Unauthorized(new
                {
                    isAuthenticated = false,
                });
            }

            return Ok(new
            {
                isAuthenticated = true,
                userName = User.Identity.Name,
            });
        }

        [HttpGet("logout")]
        [Authorize]
        public async Task<IActionResult> Logout(SignInManager<User> signInManager, [FromBody] object empty)
        {
            if (empty is null)
            {
                return Unauthorized();
            }

            await signInManager.SignOutAsync();
            return Ok();
        }
    }
}