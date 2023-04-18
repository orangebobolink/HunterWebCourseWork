﻿using DAL.Entities.UserEntities;

namespace DAL.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }
}
