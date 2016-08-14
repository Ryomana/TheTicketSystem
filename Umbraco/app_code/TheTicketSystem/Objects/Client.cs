using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

// Represents the database table Client
namespace Umbraco.Core.TheTicketSystem.Objects
{
    [TableName("Client")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class Client
    {
        public Client() { }

        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Url { get; set; } // server where we can connect with him

        public override string ToString()
        {
            return this.Name;
        }
    }
}