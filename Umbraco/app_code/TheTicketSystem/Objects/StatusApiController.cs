using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

// this is the controller for the statuses

namespace Umbraco.Core.TheTicketSystem.Objects
{
    [PluginController("theTicketSystem")]
    public class StatusApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<Status> GetAll()
        {
            var query = new Sql().Select("*").From("Status");
            return DatabaseContext.Database.Fetch<Status>(query);
        }

        public Status GetById(int id)
        {
            var query = new Sql().Select("*").From("Status").Where<Status>(x => x.Id == id);
            return DatabaseContext.Database.Fetch<Status>(query).FirstOrDefault();
        }

        public Status PostSave(Status status)
        {
            if (status.Id > 0)
            {
                DatabaseContext.Database.Update(status);
            } else
            {
                DatabaseContext.Database.Insert(status);
            }
            
            return status;
        }
    }
}