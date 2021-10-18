namespace AuthApi.Models
{
    public class User
    {
        public int id { get; set; }
        public bool active { get; set; }
        public bool blocked { get; set; }
        public int roleId { get; set; }
        public string name { get; set; }
        public string cpf { get; set; }
        public string password { get; set; }
    }
}