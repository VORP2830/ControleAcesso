namespace ControleAcesso.Domain.Entities
{
    public class Profile : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        protected Profile() { }
        public Profile(string name, string description)
        {
            Name = name;
            Description = description;
            Active = true;
        }
        public void SetActive(bool active)
        {
            Active = active;
        }
    }
}