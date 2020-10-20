namespace EntityCollectionSerializerExample.Entities
{
    using System;
    using System.Collections.Generic;
    using EntityCollectionSerializerExample.Enums;

    public class User
    {
        public Guid Id { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
