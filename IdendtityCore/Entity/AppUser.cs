using Microsoft.AspNetCore.Identity;

namespace IdendtityCore.Entity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? DealerId { get; set; }

        public bool UserActive{ get; set; }

        public Dealer Dealer { get; set; }

    }
}
