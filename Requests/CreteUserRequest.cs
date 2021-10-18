namespace AuthApi.Requests
{
    public class CreateUserRequest
    {
        public string name { get; set; }
        public string cellphone { get; set; }
        public string cpf { get; set; }
        public string password { get; set; }

    }
}