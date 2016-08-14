using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

// This is the controller class for the database table Requests
namespace Umbraco.Core.TheTicketSystem.Objects
{
    [PluginController("theTicketSystem")]
    public class RequestsApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<Requests> GetAll()
        {
            var query = new Sql().Select("*").From("Requests");
            return DatabaseContext.Database.Fetch<Requests>(query);
        }

        public Requests GetById(int id)
        {
            var query = new Sql().Select("*").From("Requests").Where<Requests>(x => x.Id == id);
            return DatabaseContext.Database.Fetch<Requests>(query).FirstOrDefault();
        }

        public Requests PostSave(Requests request)
        {
            if (request.Id > 0)
            {
                DatabaseContext.Database.Update(request);
            }
            else
            {
                DatabaseContext.Database.Insert(request);
            }

            return request;
        }

        public int DeleteById(int id)
        {
            return DatabaseContext.Database.Delete<Requests>(id);
        }

        public void AcceptRR(int id)
        {
            Requests request = this.GetById(id);
            Client client = new Client();
            client.Id = -1;
            client.Name = request.Name;
            client.Url = request.Url;

            ClientApiController cc = new ClientApiController();
            cc.PostSave(client);
            this.DeleteById(id);
            // send notification
        }

        public void DeclineRR(int id)
        {
            this.DeleteById(id);
            // send notification
        }
    }
}