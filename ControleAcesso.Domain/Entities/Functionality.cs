namespace ControleAcesso.Domain.Entities
{
    public class Functionality : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        protected Functionality() { }
        public Functionality(string name, string description)
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