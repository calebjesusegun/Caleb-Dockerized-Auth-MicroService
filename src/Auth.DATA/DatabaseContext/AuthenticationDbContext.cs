using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using src.Auth.DATA.Entities;

namespace Auth.DATA.DatabaseContext
{
   public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>
   {
      public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
      {

      }
   }
}