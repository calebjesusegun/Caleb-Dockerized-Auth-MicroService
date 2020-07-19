using System;
using System.Threading.Tasks;
using Auth.API.Interface;
using Auth.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
   [ApiController]
   public class AuthenticationController : ControllerBase
   {
      private readonly IAuthService _authService;

      public AuthenticationController(IAuthService authService)
      {
         _authService = authService;
      }

      [HttpPost("/register")]
      public async Task<IActionResult> Register(RegisterModel model)
      {

         try
         {
            if (!ModelState.IsValid) throw new ArgumentNullException(message: "Invalid Details Provided", null);

            var userName = await _authService.RegisterUser(model);
            return new CreatedResult("/register/", new { Username = userName, message = "User account created successfully" });
         }
         catch (Exception e)
         {
            return BadRequest(new { message = e.Message });
         }
      }

      // [HttpGet("/login")]
      // public IActionResult Login()
      // {
      //    throw new NotImplementedException();
      // }

      // [HttpGet("/logout")]
      // public IActionResult Logout()
      // {
      //    throw new NotImplementedException();
      // }
   }
}