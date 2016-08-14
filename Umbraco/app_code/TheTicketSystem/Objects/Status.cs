using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

// This represents a status of an Ticket; at the start 3 statuses will be created automaticly.

namespace Umbraco.Core.TheTicketSystem.Objects
{
    [TableName("Status")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class Status
    {
        public Status() { }
        public Status(string name) { this.Name = name; }

        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}