namespace ControleAcesso.Application.DTOs
{
    public class MenuOptionDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int Position { get; set; }
        public long? MenuDadId { get; set; }
        public long FunctionalityId { get; set; }
        public bool? Active { get; set; }
        public ICollection<MenuOptionDTO> Children { get; set; }
    }
}