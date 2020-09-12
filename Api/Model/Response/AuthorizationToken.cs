namespace MusicAndSocial.Api.Model.Response
{
    public class AuthorizationToken
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public string Scope { get; set; }
        public int Expires_in { get; set; }
        public string Refresh_token { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
