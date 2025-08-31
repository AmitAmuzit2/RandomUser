using System.Xml.Linq;

namespace RandomUserAPI.Entities
{
    public class User
    {
        public Name name { get; set; } = new Name();
        public string email { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
    }
    public class Name
    {
        public string title { get; set; } = string.Empty;
        public string first { get; set; } = string.Empty;
        public string last { get; set; } = string.Empty;
    }
    public class UserResult
    {
        public User[] results { get; set; } = Array.Empty<User>();
    }
}
