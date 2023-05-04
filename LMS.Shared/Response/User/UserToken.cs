namespace LMS.Shared.Response.User {
    public class UserToken {

        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Token { get; set; } = "";

        public UserToken() { }

    }
}
