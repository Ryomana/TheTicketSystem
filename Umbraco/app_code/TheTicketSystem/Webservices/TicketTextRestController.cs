using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Umbraco.Core.TheTicketSystem.Objects;

// This is the webservice for the ticketText requests

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TicketTextRestController : System.Web.Services.WebService
{

    public TicketTextRestController()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public TicketText answerTicket(string text, int ownerId, int ticketId)
    {
        TicketText t = new TicketText();
        t.Id = -1;
        t.Text = text;
        t.fiTicket = ticketId;
        t.fiAdmin = 0;
        t.isAdmin = false;
        t.fiClient = ownerId;
        t.createTS = DateTime.Now;
        t.modifyTS = DateTime.Now;

        TicketTextApiController ttc = new TicketTextApiController();
        t = ttc.PostSave(t);

        return t;
    }

}
