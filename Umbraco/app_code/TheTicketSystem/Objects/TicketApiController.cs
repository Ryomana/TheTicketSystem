using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

// this is the controller class for the table Ticket

namespace Umbraco.Core.TheTicketSystem.Objects
{

    [PluginController("theTicketSystem")]
    public class TicketApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<Ticket> GetAll()
        {
            var query = new Sql().Select("*").From("Ticket");
            return DatabaseContext.Database.Fetch<Ticket>(query);
        }

        public Ticket GetById(int id)
        {
            var query = new Sql().Select("*").From("Ticket").Where<Ticket>(x => x.Id == id);
            return DatabaseContext.Database.Fetch<Ticket>(query).FirstOrDefault();
        }

        public IList<Ticket> GetByClientId(int id)
        {
            var query = new Sql().Select("*").From("Ticket").Where<Ticket>(x => x.fiClient == id);
            return DatabaseContext.Database.Fetch<Ticket>(query);
        }

        public Ticket PostSave(Ticket ticket)
        {
            if (ticket.Id > 0)
            {
                DatabaseContext.Database.Update(ticket);
            }
            else
            {
                DatabaseContext.Database.Insert(ticket);
            }
            var tickets = this.GetByClientId(ticket.fiClient);
            ticket = tickets.Last<Ticket>();

            return ticket;
        }

        public int DeleteById(int id)
        {
            return DatabaseContext.Database.Delete<Ticket>(id);
        }

        public void SetStatus(int id, int statusId)
        {
            Ticket t = this.GetById(id);
            t.fiStatus = statusId;
            this.PostSave(t);
        }
    }
}