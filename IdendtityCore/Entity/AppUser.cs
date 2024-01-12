using Microsoft.AspNetCore.Identity;

namespace IdendtityCore.Entity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public Guid? DealerId { get; set; }

        // Navigation property for the associated Dealer
        public Dealer Dealer { get; set; }


        public bool UserActive{ get; set; }

        //public Guid ImageId { get; set; } = Guid.Parse("4084c97a-2aa1-4675-b519-69f6fe410633");
        // public Image Image { get; set; }

        // public ICollection<Article> Articles { get; set; }
    }
}
