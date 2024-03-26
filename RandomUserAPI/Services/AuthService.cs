namespace RandomUserAPI.Services
{
    public class AuthService
    {
        private string _username;
        private string _password;

        public AuthService(string username, string password)
        {
            //_username = username ?? throw new ArgumentNullException(nameof(username));
            //_password = password ?? throw new ArgumentNullException(nameof(password));
            _username = username;
            _password = password;
        }
        public bool Authenticate(string username, string password)
        {
            return _username == username && _password == password;
        }
    }
}
