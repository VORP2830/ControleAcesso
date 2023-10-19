namespace ControleAcesso.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public long UserId { get; private set; }
        public long ProfileId { get; private set; }
        public User User { get; set; }
        public Profile Profile { get; set; }
        public IEnumerable<Profile> Profilies { get; set; }
        public IEnumerable<User> Users { get; set; }
        protected UserProfile() { }
        public UserProfile(long userId, long profileId)
        {
            UserId = userId;
            ProfileId = profileId;
            Active = true;
        }
    }
}