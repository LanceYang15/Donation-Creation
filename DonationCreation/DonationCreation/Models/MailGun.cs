using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;

namespace DonationCreation.Models
{
    public class MailGun
    {

        public static IRestResponse SendSimpleMessage(string recieverEmail, string text)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
            new HttpBasicAuthenticator("api",
                                      "API_KEY");

            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox7899273d1a254a2d989b5bd1acee3ff9.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox7899273d1a254a2d989b5bd1acee3ff9.mailgun.org>");
            request.AddParameter("to", recieverEmail);
            request.AddParameter("subject", "Tracking Number");
            request.AddParameter("text", text);
            request.Method = Method.POST;
            return client.Execute(request);
        }


    }
}