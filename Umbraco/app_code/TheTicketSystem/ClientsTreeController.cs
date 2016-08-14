using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using Umbraco.Core;
using Umbraco.Core.TheTicketSystem.Objects;

// This class represents the client tree in the backend

namespace Umbraco.Core.TheTicketSystem
{

    [Tree("theTicketSystem", "clientsTree", "Clients")]
    [PluginController("theTicketSystem")]
    public class ClientsTreeController : TreeController
    {
        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            var menu = new MenuItemCollection();
            return menu;
        }

        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            if (id == Constants.System.Root.ToInvariantString())
            {
                var ctrl = new ClientApiController();
                var nodes = new TreeNodeCollection();

                foreach (var client in ctrl.GetAll())
                {
                    var node = CreateTreeNode(
                        client.Id.ToString(),
                        "-1",
                        queryStrings,
                        client.ToString(),
                        "icon-user",
                        false);

                    nodes.Add(node);
                }

                return nodes;
            }

            throw new NotSupportedException();
        }
    }
}