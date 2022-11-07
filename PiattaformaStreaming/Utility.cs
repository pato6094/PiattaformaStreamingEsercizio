using System;

namespace PiattaformaStreaming
{
    static class Utility
    {
       public static void Start()
        {
            Application Spotify = new Application("Spotify");
            Application AmazonMusic = new Application("Amazon Music");
            Application AppleMusic = new Application("Apple Music");
            AppSelecter(Spotify, AmazonMusic, AppleMusic);
        }


        private static void AppSelecter(Application Spotify, Application AmazonMusic,Application AppleMusic)
        {
            string application;
            do
            {
                Console.WriteLine("Select an application to stream music:  press 'S' for Spotify,  'M' for Amazon Music  or  'A' for Apple Music");
                application = Console.ReadLine();
            } while ((application != "S") && (application != "M") && (application != "A"));

            if (application == "S")
            {
                UserRegistrationS(Spotify);
            }
            else if (application == "M")
            {
                UserRegistrationM(AmazonMusic);
            }
            else
            {
                UserRegistrationA(AppleMusic);
            }
        }

        private static void UserRegistrationS(Application Spotify)
        {
            string registred;
            do
            {
                Console.WriteLine("If you are already registred press 'L' else press 'R'.  If you want to close the App press 'E'");
                registred = Console.ReadLine();
            } while (registred != "L" && registred != "R" && registred != "E");

            if (registred == "L")
            {
                Spotify.LogIn();
                MusicSelecterS(Spotify);
            }
            else if (registred == "R")
            {
                Spotify.Registration();
                UserRegistrationS(Spotify);
            }
            else
            {
                Start();
            }
        }
        private static void MusicSelecterS(Application Spotify)
        {
            string Select;
            do
            {
                Console.WriteLine("Select the track: '1' for Fabri Fibra - Bugiardo, '2' for Steve Vai - Tender Surrender, '3' for Lazza - Sogni D'Oro  or press 'P' to play the current song. If you want to close the App press 'E'");
                Select = Console.ReadLine();
            } while (Select != "1" && Select != "2" && Select != "3"  && Select != "P" && Select != "E");

            if (Select == "1")
            {
                if (Spotify.SetStreamingSong(0))
                {
                    Spotify.Play();
                }
                else Spotify.Play();

                MusicActionS(Spotify);
            }
            else if (Select == "2")
            {
                if (Spotify.SetStreamingSong(1))
                {
                    Spotify.Play();
                }
                else Spotify.Play();

                MusicActionS(Spotify);
            }
            else if (Select == "3")
            {
                if (Spotify.SetStreamingSong(2))
                {
                    Spotify.Play();
                }
                else Spotify.Play();

                MusicActionS(Spotify);
            }
            
            else if (Select == "P")
            {
                if (Spotify.Play())
                {
                    MusicActionS(Spotify);
                }
                else
                {
                    Console.WriteLine("No current song");
                    MusicSelecterS(Spotify);
                }
            }
            else
            {
                Start();
            }
        }

        private static void MusicActionS(Application Spotify)
        {
            string action;
            do
            {
                Console.WriteLine("Press 'S' to stop, 'P' to pause, 'F' to forward, 'B' to backward or 'R' to Rate the song. If you want to close the App press 'E'");
                action = Console.ReadLine();
            } while (action != "S" && action != "P" && action != "F" && action != "B" && action != "R" && action != "E");

            if (action == "S")
            {
                Spotify.Stop();
                MusicSelecterS(Spotify);
            }
            else if (action == "P")
            {
                Spotify.Pause();
                MusicSelecterS(Spotify);
            }
            else if (action == "F")
            {
                Spotify.Forward();
                MusicActionS(Spotify);
            }
            else if (action == "R")
            {
                Spotify.Rate();
                MusicActionS(Spotify);
            }
            else if (action == "B")
            {
                Spotify.Backward();
                MusicActionS(Spotify);
            }
            else
            {
                Start();
            }
        }

        private static void UserRegistrationM(Application AmazonMusic)
        {
            string registred;
            do
            {
                Console.WriteLine("If you are already registred press 'L' else press 'R'. If you want to close the App press 'E'");
                registred = Console.ReadLine();
            } while (registred != "L" && registred != "R" && registred != "E");

            if (registred == "L")
            {
                AmazonMusic.LogIn();
                MusicSelecterM(AmazonMusic);
            }
            else if (registred == "R")
            {
                AmazonMusic.Registration();
                UserRegistrationM(AmazonMusic);
            }
            else
            {
                Start();
            }
        }

        private static void MusicSelecterM(Application AmazonMusic)
        {
            string Select;
            do
            {
                Console.WriteLine("Select the track: '1' for Fabri Fibra - Bugiardo, '2' for Steve Vai - Tender Surrender, '3' for Lazza - Sogni D'Oro  or press 'P' to play the current song. If you want to close the App press 'E'");
                Select = Console.ReadLine();
            } while (Select != "1" && Select != "2" && Select != "3" && Select != "P" && Select != "E");

            if (Select == "1")
            {
                if (AmazonMusic.SetStreamingSong(1))
                {
                    AmazonMusic.Play();
                }
                else AmazonMusic.Play();

                MusicActionM(AmazonMusic);
            }
            else if (Select == "2")
            {
                if (AmazonMusic.SetStreamingSong(2))
                {
                    AmazonMusic.Play();
                }
                else AmazonMusic.Play();

                MusicActionM(AmazonMusic);
            }
            else if (Select == "3")
            {
                if (AmazonMusic.SetStreamingSong(3))
                {
                    AmazonMusic.Play();
                }
                else AmazonMusic.Play();

                MusicActionM(AmazonMusic);
            }
            else if (Select == "P")
            {
                AmazonMusic.Play();
                MusicActionM(AmazonMusic);
            }
            else
            {
                Start();
            }
        }

        private static void MusicActionM(Application AmazonMusic)
        {
            string action;
            do
            {
                Console.WriteLine("Press 'S' to stop, 'P' to pause, 'F' to forward, 'B' to backward or 'R' to Rate the song. If you want to close the App press 'E'");
                action = Console.ReadLine();
            } while (action != "S" && action != "P" && action != "F" && action != "B" && action != "R" && action != "E");

            if (action == "S")
            {
                AmazonMusic.Stop();
                MusicSelecterM(AmazonMusic);
            }
            else if (action == "P")
            {
                AmazonMusic.Pause();
                MusicSelecterM(AmazonMusic);
            }
            else if (action == "F")
            {
                AmazonMusic.Forward();
                MusicActionM(AmazonMusic);
            }
            else if (action == "R")
            {
                AmazonMusic.Rate();
                MusicActionM(AmazonMusic);
            }
            else if (action == "B")
            {
                AmazonMusic.Backward();
                MusicActionM(AmazonMusic);
            }
            else
            {
                Start();
            }
        }

        private static void UserRegistrationA(Application AppleMusic)
        {
            string registred;
            do
            {
                Console.WriteLine("If you are already registred press 'L' else press 'R'. If you want to close the App press 'E'");
                registred = Console.ReadLine();
            } while (registred != "L" && registred != "R" && registred != "E");

            if (registred == "L")
            {
                AppleMusic.LogIn();
                MusicSelecterA(AppleMusic);
            }
            else if (registred == "R")
            {
                AppleMusic.Registration();
                UserRegistrationA(AppleMusic);
            }
            else
            {
                Start();
            }
        }

        private static void MusicSelecterA(Application AppleMusic)
        {
            string Select;
            do
            {
                Console.WriteLine("Select the track: '1' for Fabri Fibra - Bugiardo, '2' for Steve Vai - Tender Surrender, '3' for Lazza - Sogni D'Oro  or press 'P' to play the current song. If you want to close the App press 'E'");
                Select = Console.ReadLine();
            } while (Select != "1" && Select != "2" && Select != "3" && Select != "P" && Select != "E");

            if (Select == "1")
            {
                if (AppleMusic.SetStreamingSong(1))
                {
                    AppleMusic.Play();
                }
                else AppleMusic.Play();

                MusicActionA(AppleMusic);
            }
            else if (Select == "2")
            {
                if (AppleMusic.SetStreamingSong(2))
                {
                    AppleMusic.Play();
                }
                else AppleMusic.Play();

                MusicActionA(AppleMusic);
            }
            else if (Select == "3")
            {
                if (AppleMusic.SetStreamingSong(3))
                {
                    AppleMusic.Play();
                }
                else AppleMusic.Play();

                MusicActionA(AppleMusic);
            }
            else if (Select == "P")
            {
                AppleMusic.Play();
                MusicActionA(AppleMusic);
            }
            else
            {
                Start();
            }
        }

        private static void MusicActionA(Application AppleMusic)
        {
            string action;
            do
            {
                Console.WriteLine("Press 'S' to stop, 'P' to pause, 'F' to forward, 'B' to backward or 'R' to Rate the song. If you want to close the App press 'E'");
                action = Console.ReadLine();
            } while (action != "S" && action != "P" && action != "F" && action != "B" && action != "R" && action != "E");

            if (action == "S")
            {
                AppleMusic.Stop();
                MusicSelecterA(AppleMusic);
            }
            else if (action == "P")
            {
                AppleMusic.Pause();
                MusicSelecterA(AppleMusic);
            }
            else if (action == "F")
            {
                AppleMusic.Forward();
                MusicActionA(AppleMusic);
            }
            else if (action == "R")
            {
                AppleMusic.Rate();
                MusicActionA(AppleMusic);
            }
            else if (action == "B")
            {
                AppleMusic.Backward();
                MusicActionA(AppleMusic);
            }
            else
            {
                Start();
            }
        }
    }
}



  