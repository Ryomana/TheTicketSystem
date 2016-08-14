using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace Umbraco.Core.TheTicketSystem.Objects
{

    [PluginController("theTicketSystem")]
    public class TicketTextApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<TicketText> GetAll()
        {
            var query = new Sql().Select("*").From("TicketText");
            return DatabaseContext.Database.Fetch<TicketText>(query);
        }

        public TicketText GetById(int id)
        {
            var query = new Sql().Select("*").From("TicketText").Where<TicketText>(x => x.Id == id);
            return DatabaseContext.Database.Fetch<TicketText>(query).FirstOrDefault();
        }

        public IEnumerable<TicketText> GetByTicketId(int id)
        {
            var query = new Sql().Select("*").From("TicketText").Where<TicketText>(x => x.fiTicket == id).OrderBy("createTS");
            return DatabaseContext.Database.Fetch<TicketText>(query);
        }

        public TicketText PostSave(TicketText ticketText)
        {
            if (ticketText.Id > 0)
            {
                DatabaseContext.Database.Update(ticketText);
            }
            else
            {
                DatabaseContext.Database.Insert(ticketText);
            }
            ticketText = this.GetByTicketId(ticketText.fiTicket).Last<TicketText>();

            return ticketText;
        }

        public int DeleteById(int id)
        {
            return DatabaseContext.Database.Delete<TicketText>(id);
        }
    }
}