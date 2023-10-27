using ControleAcesso.Domain.Validation;

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
        public FunctionalityProfile(long id, long profileId, long functionalityId)
        {
            DomainExceptionValidation.When(id < 0, "Id invalido. O id deve ser maior que 0");
            Id = id;
            ProfileId = profileId;
            FunctionalityId = functionalityId;
            Active = true;
        }
    }
}