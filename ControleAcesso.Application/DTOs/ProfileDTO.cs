namespace ControleAcesso.Application.DTOs
{
    public class ProfileDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<UserProfileDTO> UserProfilesDTO { get; set; }
        public IEnumerable<FunctionalityProfileDTO> FunctionalityProfilesDTO { get; set; }
    }
}