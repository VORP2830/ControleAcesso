namespace ControleAcesso.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; protected set; }
        public bool Active { get; protected set; } 
        public DateTime ModifiedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public void SetActive(bool active)
        {
            Active = active;
        }
    }
}