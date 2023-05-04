using LMS.Shared.Enums;

namespace LMS.Shared.Requests.Users {
    public class UserUpdateRequest {

        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public UserSituation Situation { get; set; }

    }
}
