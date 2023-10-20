namespace ControleAcesso.Domain.Entities
{
    public class FunctionalityProfile : BaseEntity
    {
        public long ProfileId { get; private set; }
        public long FuncionalityId { get; private set; }
        public Profile Profile { get; private set; }
        public Functionality Functionality { get; set; }
        public IEnumerable<Functionality> Functionalities { get; set; }
        public IEnumerable<Profile> Profiles { get; set; }
        protected FunctionalityProfile() { }
        public FunctionalityProfile(long profileId, long funcionalityId)
        {
            ProfileId = profileId;
            FuncionalityId = funcionalityId;
            Active = true;
        }
    }
}