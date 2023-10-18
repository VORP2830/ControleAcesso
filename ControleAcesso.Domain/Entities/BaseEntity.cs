namespace ControleAcesso.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime ModifiedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}