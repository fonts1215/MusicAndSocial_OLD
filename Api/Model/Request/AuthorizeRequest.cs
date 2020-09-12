using System.Collections.Generic;

namespace MusicAndSocial.Api.Model.Request
{
    public class AuthorizeRequest
    {
        public string Client_Id { get; set; }
        public string Response_Type { get; set; } = "code";
        public string Redirect_IUri { get; set; }
        public string State { get; set; }
        public List<string> Scope { get; set; }

        public AuthorizeRequest(string client_Id, string response_Type, string redirect_IUri, string state, List<string> scope)
        {
            Client_Id = client_Id;
            Response_Type = response_Type;
            Redirect_IUri = redirect_IUri;
            State = state;
            Scope = scope;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
