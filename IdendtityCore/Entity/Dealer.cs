namespace IdendtityCore.Entity
{
    public class Dealer
    {
        public Guid DealerId { get; set; }

        public string DealerName { get; set; }

        public List<AppUser> Users { get; set; }
    }
}
