using System.Collections.Generic;

namespace MusicAndSocial.Common.Constants
{
    public static class Tokens
    {
        public static string ClientId = ""; //demo app set 
        public static string SecretId = "";
        public static List<string> Scope 
            = new List<string>
            { 
                "user-read-playback-state", 
                "user-read-currently-playing",
                "playlist-read-collaborative", 
                "user-library-read",
                "user-top-read",
                "user-read-recently-played",
                "user-follow-read"
            };
    }
}
