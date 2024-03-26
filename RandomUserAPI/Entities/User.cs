using System.Xml.Linq;

namespace RandomUserAPI.Entities
{
    public class User
    {
        public Name name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }
    public class UserResult
    {
        public User[] results { get; set; }
    }
}
