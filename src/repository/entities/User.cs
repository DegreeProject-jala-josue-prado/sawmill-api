namespace yume_api.src.repository.entities
{
    public class User : IEntityBase
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public UserRol Rol { get; set; }
    }
}
