namespace ControleAcesso.Application.Exceptions
{
    public class ControleAcessoException : Exception
    {
        public ControleAcessoException(string error) : base(error) { }
    }
}