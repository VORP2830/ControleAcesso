namespace ControleAcesso.Application.DTOs
{
    public class ProfileDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
    }
}