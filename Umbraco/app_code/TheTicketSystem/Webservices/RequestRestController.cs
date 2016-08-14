using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Umbraco.Core.TheTicketSystem.Objects;

// This is the webservice for the client registration requests

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class RequestRestController : System.Web.Services.WebService
{

    public RequestRestController()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void sendRequest(string name, string url)
    {
        RequestsApiController api = new RequestsApiController();
        Requests request = new Requests();
        request.Id = -1;
        request.Name = name;
        request.Url = url;
        api.PostSave(request);
    }

}
