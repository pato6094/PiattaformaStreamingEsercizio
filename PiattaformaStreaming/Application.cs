using System;
using System.Collections.Generic;

namespace PiattaformaStreaming
{
    public partial class Application : StreamingPlatform
    {
        private List<User> application_users;
        private User application_log_user;
        
        public Application(string _application_name) : base(_application_name)
        {
            Song a = new Song("Fabri Fibra - Bugiardo", 2);
            Song b = new Song("Steve Vai - Tender Surrender", 3);
            Song c = new Song("Lazza - Sogni D'Oro", 4);
            application_tracks.Add(a);
            application_tracks.Add(b);
            application_tracks.Add(c);
            application_name = _application_name;

            application_users = new List<User>();
            
        }


        public bool SetStreamingSong(int index)
        {
            if (streaming_song != application_tracks[index])
            {
                streaming_song = application_tracks[index];
                return true;
            }
            else return false;
        }





        protected sealed override bool AccessVerified(User user_login)
        {
            for (int i = 0; i < application_users.Capacity; i++) {
                if (user_login.Username == application_users[i].Username && user_login.Password == application_users[i].Password)
                    return false; 
            }
            return true;
        }
        public bool Registration()
        {
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            User user_registration = new User(username, password);
            if (application_users.IndexOf(user_registration) == -1)
            {
                application_users.Add(user_registration);
                return true;
            }
            else
            {
                Console.WriteLine("User already added");
                return false;
            }

        }








        public void LogIn()
        {
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            User user_login = new User(username, password);

            if (AccessVerified(user_login))
            {
                application_log_user = user_login;
                Console.WriteLine("You are Logged In");

            }
            else
            {
                Console.WriteLine("User not found please register");
                Registration();

            }
        }
    }
}









