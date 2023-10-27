namespace ControleAcesso.Application.DTOs
{
    public class UserProfileDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProfileId { get; set; }
        public bool? Active { get; set; }
    }
}