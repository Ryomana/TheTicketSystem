using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using umbraco;
using Umbraco.Core.Configuration;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

// This is the controller for the configuration file

namespace Umbraco.Core.TheTicketSystem.Configuration
{

    [PluginController("theTicketSystem")]
    public class TheTicketSystemConfigController : UmbracoAuthorizedJsonController
    {
        // Return the configurations
        public TheTicketSystemConfiguration GetConfig()
        {
            return TheTicketSystemConfiguration.GetConfig();
        }

        // set an attribute value (LINQ was used)
        public void SetAttributeValue(string attrName, string value)
        {
            // path to the config file
            var configPath = GlobalSettings.FullpathToRoot + "\\App_Plugins\\theTicketSystem\\TheTicketSystem.config";
            XElement xelement = XElement.Load(configPath); // get the config tree
            IEnumerable<XElement> attributes = xelement.Elements(); // get the elements of the tree as a list
            foreach (var attr in attributes)
            {
                if (attr.Name == attrName)
                { // check if correct attribute
                    XAttribute attrValue = attr.Attribute("value"); // get the attibute as an XAttribute
                    attrValue.SetValue(value); // change attribute
                }
            }
            xelement.Save(configPath);
        }
    }
}