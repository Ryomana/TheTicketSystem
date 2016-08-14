using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Core.TheTicketSystem.Objects;

// This file makes configurations when the system gets installed. It installs the database for example.

namespace Umbraco.Core.TheTicketSystem
{

    public class RegisterEvents : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var db = applicationContext.DatabaseContext.Database;

            // Create Status table if not exists
            if (!db.TableExist("Status"))
            {
                db.CreateTable<Status>(false);
                Status newStatus = new Status("New");
                Status ipStatus = new Status("In progress");
                Status closedStatus = new Status("Closed");

                StatusApiController sc = new StatusApiController();
                sc.PostSave(newStatus);
                sc.PostSave(ipStatus);
                sc.PostSave(closedStatus);
            }

            // Create client table if not exists
            if (!db.TableExist("Client"))
            {
                db.CreateTable<Client>(false);
            }

            // Create ticket table if not exists
            if (!db.TableExist("Ticket"))
            {
                db.CreateTable<Ticket>(false);
            }

            // Create ticketText table if not exists
            if (!db.TableExist("TicketText"))
            {
                db.CreateTable<TicketText>(false);
            }

            // Create Requests table if not exists
            if (!db.TableExist("Requests"))
            {
                db.CreateTable<Requests>(false);
            }
        }
    }
}