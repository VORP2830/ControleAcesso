namespace ControleAcesso.Application.DTOs
{
    public class FunctionalityProfileDTO
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public long FunctionalityId { get; set; }
        public bool? Active { get; set; }
    }
}