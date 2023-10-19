namespace ControleAcesso.Domain.Entities
{
    public class FuncionalityProfile : BaseEntity
    {
        public long ProfileId { get; private set; }
        public long FuncionalityId { get; private set; }
        public Profile Profile { get; private set; }
        public Functionality Functionality { get; set; }
        public IEnumerable<Functionality> Functionalities { get; set; }
        protected FuncionalityProfile() { }
        public FuncionalityProfile(long profileId, long funcionalityId)
        {
            ProfileId = profileId;
            FuncionalityId = funcionalityId;
            Active = true;
        }
    }
}