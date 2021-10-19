namespace AuthApi.Dtos
{
    public class UserDto
    {
        public int id { get; set; }
        public bool active { get; set; }
        public bool blocked { get; set; }
        public int roleId { get; set; }
        public string cpf { get; set; }

        public RoleDto role { get; set; }
    }
}