namespace ControleAcesso.Application.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IEnumerable<UserProfileDTO> UserProfileDTOs { get; set; }
    }
}