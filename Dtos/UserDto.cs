namespace AuthApi.Dtos
{
    public class UserDto
    {
        public int ind { get; set; }
        public bool active { get; set; }
        public bool blocked { get; set; }
        public int roleId { get; set; }
        public string cpf { get; set; }
    }
}