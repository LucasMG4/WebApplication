﻿using LMS.Shared.Enums;

namespace LMS.Shared.Response.User {
    public class UserResponse {

        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Login { get; set; } = "";
        public string Email { get; set; } = "";
        public UserSituation Situation { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

    }
}
