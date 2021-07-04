using System.IO;

namespace SpotifyBot.Service.Spotify
{
    public partial class SpotifyService
    {
        public static string app_id;  //Id of my spotify app
        public static string app_ids; //secret Id 

        private static readonly string configPath = @".\_config.json";
        private static readonly string t_configPath = @"C:\Users\Марко\OneDrive\Desktop\Discord\TestBotStuff\TestBot_\bot\t_config.json";
        //^ this is test config file

        private static void GetSpotifyTokens() //Method to get spotify tokens
        {
            StreamReader r = new StreamReader(t_configPath);
            string json = r.ReadToEnd();
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            app_id = data.Spotify_id;
            app_ids = data.Spotify_ids;

        }

        static SpotifyService()
        {
            GetSpotifyTokens();
        }
    }
}