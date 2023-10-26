namespace ControleAcesso.Application.DTOs
{
    public class FunctionalityDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MenuOptionDTO MenuOptionDTO { get; set; }
        public IEnumerable<MethodDTO> MethodsDTO { get; set; }
        public IEnumerable<FunctionalityProfileDTO> FunctionalityProfilesDTO { get; set; }
    }
}