using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PiattaformaStreaming.Application;
using System.Timers;

namespace PiattaformaStreaming
{
    public enum SongStatus
    {
        Play,
        Stop,
        Pause
    }
    public abstract class StreamingPlatform : Player
    {
        protected string application_name;
        protected List<Song> application_tracks;
        protected Song streaming_song;
        protected Dictionary<Song, int> rated_songs;

        protected Timer streaming_timer;
        private int elapsedSeconds;
        protected abstract bool AccessVerified(User user_login);
        public StreamingPlatform(string _application_name)
        {
            application_name = _application_name;
            application_tracks = new List<Song>();
            rated_songs = new Dictionary<Song, int>();
            streaming_timer = new Timer(1000);
            elapsedSeconds = 0;
        }
        public void AddSong(string _song_name, int _song_duration)
        {
            Song newSong = new Song(_song_name, _song_duration);

            if (application_tracks.IndexOf(newSong) != -1)
                application_tracks.Add(newSong);
        }

        public void RemoveSong(string _song_name, int _song_duration)
        {
            Song newSong = new Song(_song_name, _song_duration);

            if (application_tracks.IndexOf(newSong) != -1)
                application_tracks.Remove(newSong);
        }

        protected class Song
        {
            private string song_name;
            private int song_rate;
            private SongStatus song_status;
            private int song_duration;
            private int song_actual_time;

            public Song(string _song_name, int _song_duration)
            {
                song_name = _song_name;
                song_duration = _song_duration;
                song_status = SongStatus.Stop;
                song_actual_time = 0;
            }

            public string Name { get { return song_name; } set { song_name = value; } }
            public int Rate { get { return song_rate; } set { song_rate = value; } }
            public SongStatus Status { get { return song_status; } set { song_status = value; } }
            public int Duration { get { return song_duration; } set { song_duration = value; } }
            public int ActualTime { get { return song_actual_time; } set { song_actual_time = value; } }
        }



        internal void startTimer()
        {
            elapsedSeconds++;
            streaming_song.ActualTime = elapsedSeconds;
        }

        internal void stopTimer()
        {
            elapsedSeconds = 0;
        }

        public bool Play()
        {
            if (streaming_song != null)
            {
                streaming_song.Status = SongStatus.Play;
                Console.WriteLine(streaming_song.Name);
                streaming_timer.Start();
                startTimer();
                return true;
            }
            return false;
        }

        public void Stop()
        {
            if (streaming_song != null)
            {
                streaming_song.Status = SongStatus.Stop;
                streaming_song.ActualTime = 0;

                streaming_timer.Stop();
                stopTimer();
            }
        }
        public void Pause()
        {
            if (streaming_song != null)
            {
                streaming_song.Status = SongStatus.Pause;

                streaming_song.ActualTime = elapsedSeconds;
                streaming_timer.Stop();
            }
        }

        public void Rate()
        {
            if (streaming_song != null)
            {
                int newrate = 0;
                bool catchvalue = false;
                while (catchvalue == false)
                {
                    Console.Clear();
                    Console.WriteLine("Vote this Song (1/5): ");
                    catchvalue = Int32.TryParse(Console.ReadLine(), out newrate);
                }

                if (rated_songs[streaming_song] != 0)
                    rated_songs[streaming_song] = (streaming_song.Rate + newrate) / 2;
                else rated_songs.Add(streaming_song, newrate);
            }
        }
        public void Forward()
        {
            if (streaming_song != null)
            {
                int index = application_tracks.IndexOf(streaming_song);
                streaming_song.ActualTime = 0;

                if (index >= application_tracks.Count - 1)
                    streaming_song = application_tracks[0];
                else streaming_song = application_tracks[index + 1];

                if (streaming_song.Status != SongStatus.Play)
                    streaming_song.Status = SongStatus.Play;

                stopTimer();
                startTimer();
            }
        }

        public void Backward()
        {
            if (streaming_song != null)
            {
                int index = application_tracks.IndexOf(streaming_song);

                if (streaming_song.ActualTime == 0)
                {
                    streaming_song.ActualTime = 0;

                    if (index <= 0)
                        streaming_song = application_tracks[application_tracks.Count - 1];
                    else streaming_song = application_tracks[index - 1];

                    if (streaming_song.Status != SongStatus.Play)
                        streaming_song.Status = SongStatus.Play;
                }

                stopTimer();
                startTimer();

            }
        }

        void Player.Play()
        {
            throw new NotImplementedException();
        }
    }





    interface Player
    {
        void Play();
        void Stop();
        void Pause();
        void Rate();
        void Forward();
        void Backward();
    }


}


