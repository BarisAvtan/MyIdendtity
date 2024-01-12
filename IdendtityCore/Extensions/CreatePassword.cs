using IdendtityCore.Entity;
using Microsoft.AspNetCore.Identity;

namespace IdendtityCore.Extensions
{
    public static class PasswordExtensions
    {
        public static string CreatePasswordHash(this AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
