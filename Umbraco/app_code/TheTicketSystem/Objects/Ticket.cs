using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

// represents the database table Ticket

namespace Umbraco.Core.TheTicketSystem.Objects
{
    [TableName("Ticket")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class Ticket
    {
        public Ticket() {
            this.fiStatus = 1; // 1 = new 
        }

        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [ForeignKey(typeof(Client))]
        public int fiClient { get; set; }

        [ForeignKey(typeof(Status))]
        public int fiStatus { get; set; }
    }
}