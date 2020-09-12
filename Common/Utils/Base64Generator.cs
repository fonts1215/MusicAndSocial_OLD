namespace MusicAndSocial.Common.Utils
{
    public class Base64Generator
    {
        public static string GetBase64(string client_id, string secret_id) => 
             System.Convert.ToBase64String(
                 System.Text.Encoding.GetEncoding("ISO-8859-1")
                 .GetBytes(client_id + ":" + secret_id));
    }
}
