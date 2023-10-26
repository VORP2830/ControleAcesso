namespace ControleAcesso.Application.DTOs
{
    public class UserProfileDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProfileId { get; set; }
        public UserDTO UserDTO { get; set; }
        public ProfileDTO ProfileDTO { get; set; }
    }
}