namespace ControleAcesso.Application.DTOs
{
    public class MethodDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public long FunctionalityId { get; set; }
        public FunctionalityDTO FunctionalityDTO { get; set; }
    }
}