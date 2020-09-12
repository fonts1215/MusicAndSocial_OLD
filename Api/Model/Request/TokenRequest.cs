namespace MusicAndSocial.Api.Model.Request
{
    public class TokenRequest
    {
        public string Grant_type { get; set; } = "authorization_code";
        public string Code { get; set; }
        public string Redirect_uri { get; set; }
        public string Client_Id { get; set; }
        public string Client_Secret { get; set; }

        public TokenRequest(string code, string redirect_uri, string client_Id, string client_Secret)
        {
            Code = code;
            Redirect_uri = redirect_uri;
            Client_Id = client_Id;
            Client_Secret = client_Secret;
        }
    }
}
