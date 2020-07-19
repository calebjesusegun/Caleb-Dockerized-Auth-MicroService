using System.Text;
using System;
using System.Threading.Tasks;
using Auth.API.Interface;
using Auth.API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using src.Auth.DATA.Entities;

namespace Auth.API.Services
{
   public class AuthService : IAuthService
   {
      private readonly UserManager<ApplicationUser> _userManager;

      public AuthService(UserManager<ApplicationUser> userManager)
      {
         _userManager = userManager;
      }

      public async Task<string> RegisterUser(RegisterModel model)
      {
         if (model is null) throw new ArgumentNullException(message: "Invalid Details Provided", null);

         ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

         if (user is null)
         {
            user = new ApplicationUser
            {
               UserName = model.Email,
               Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
               throw new InvalidOperationException(message: AddErrors(result), null);
            }
         }
         return user.UserName;
      }

      private string AddErrors(IdentityResult result)
      {
         StringBuilder sb = new StringBuilder();
         foreach (var error in result.Errors)
         {
            sb.Append(error.Description + " ");
         }
         return sb.ToString();
      }
   }
}