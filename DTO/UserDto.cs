namespace EntityCollectionSerializerExample.DTO
{
    using System.Collections.Generic;
    using System.Linq;
    using EntityCollectionSerializerExample.Entities;

    public class UserDto
    {
        public string Id { get; set; }
        public ICollection<string> UserRoles { get; set; }

        public UserDto(User user)
        {
            Id = user.Id.ToString();
            UserRoles = user.UserRoles.Select(role => role.ToString()).ToList();
        }
    }
}
