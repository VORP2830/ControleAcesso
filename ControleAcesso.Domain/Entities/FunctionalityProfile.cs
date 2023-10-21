namespace ControleAcesso.Domain.Entities
{
    public class FunctionalityProfile : BaseEntity
    {
        public long ProfileId { get; private set; }
        public long FunctionalityId { get; private set; }
        public Profile Profile { get; private set; }
        public Functionality Functionality { get; private set; }
        protected FunctionalityProfile() { }
        public FunctionalityProfile(long profileId, long functionalityId)
        {
            ProfileId = profileId;
            FunctionalityId = functionalityId;
            Active = true;
        }
    }
}