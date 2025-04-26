namespace yume_api.src.dtos
{
    public class UserDTO : IDTOBase
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public UserRol Rol { get; set; }
    }
}
