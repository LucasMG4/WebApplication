using LMS.Shared.Enums;

namespace LMS.Shared.Requests.Users {
    public class UserAddRequest {

        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public UserSituation Situation { get; set; }


    }
}
