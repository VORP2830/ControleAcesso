namespace ControleAcesso.Domain.Entities
{
    public class UserAccess
    {
        public long Id { get; private set; }
        public string UserName { get; private set; }
        public string IP { get; private set; }
        public bool Success { get; private set; }
        public DateTime AccessDate { get; private set; }
        protected UserAccess() { }
        public UserAccess(string userName, string ip)
        {
            UserName = userName;
            IP = ip;
            AccessDate = DateTime.Now;
            Success = false;
        }
        public void SetSuccess(bool success)
        {
            Success = success;
        }
    }
}