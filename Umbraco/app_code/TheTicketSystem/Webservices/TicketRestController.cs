using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Umbraco.Core.TheTicketSystem.Objects;

// This is the webservice for the ticket requests

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TicketRestController : System.Web.Services.WebService
{

    public TicketRestController()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public Ticket createTicket(string subject, string text,int ownerId) {
        Ticket ticket = new Ticket();
        ticket.Id = -1;
        ticket.Subject = subject;
        ticket.fiClient = ownerId;

        TicketApiController tc = new TicketApiController();
        ticket = tc.PostSave(ticket);

        TicketText tt = new TicketText();
        tt.Id = -1;
        tt.Text = text;
        tt.isAdmin = false;
        tt.fiClient = ownerId;
        tt.fiAdmin = 0;
        tt.fiTicket = ticket.Id;

        TicketTextApiController ttc = new TicketTextApiController();
        ttc.PostSave(tt);

        return ticket;
    }

    [WebMethod]
    public void setStatus(int ticketId, int statusId)
    {
        TicketApiController tc = new TicketApiController();
        tc.SetStatus(ticketId, statusId);
    }

    [WebMethod]
    public List<Ticket> getAllTickets(int id)
    {
        TicketApiController tc = new TicketApiController();
        return tc.GetByClientId(id).ToList<Ticket>();
    }
}
