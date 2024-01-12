using System.ComponentModel.DataAnnotations;

namespace IdendtityCore.Entity.UserEntity
{
    public class AddUser
    {

        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        // Navigation property for the associated Dealer
        public Dealer Dealer { get; set; }

        public bool UserActive { get; set; }


    }
}
