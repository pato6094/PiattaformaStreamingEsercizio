namespace PiattaformaStreaming
{

    public partial class Application
    {
        public class User
        {
            private string user_username;
            private string user_password;



            public string Username { get { return user_username; } set { user_username = value; } }
            public string Password { get { return user_password; } set { user_password = value; } }

            public User(string user_username, string user_password)
            {
                this.user_username = user_username;
                this.user_password = user_password;
            }
        }

    }


}


