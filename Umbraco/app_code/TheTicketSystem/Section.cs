using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.businesslogic;
using umbraco.interfaces;

// This creates the section for theTicketSystem

namespace Umbraco.Core.TheTicketSystem
{

    [Application("theTicketSystem", "TheTicketSystem", "icon-people", 15)]
    public class Section : IApplication { }
}