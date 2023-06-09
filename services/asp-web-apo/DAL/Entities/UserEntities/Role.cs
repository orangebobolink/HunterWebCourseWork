﻿namespace DAL.Entities.UserEntities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new();
        public List<RoleUser> RoleUsers { get; set; } = new();

        public override string? ToString()
        {
            return Name;
        }
    }
}
