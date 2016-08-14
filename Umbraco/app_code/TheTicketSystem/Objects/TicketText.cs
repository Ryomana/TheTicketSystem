using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace Umbraco.Core.TheTicketSystem.Objects
{

    [TableName("TicketText")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class TicketText
    {
        public TicketText()
        {
            createTS = DateTime.Now;
            modifyTS = DateTime.Now;
        }

        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [ForeignKey(typeof(Client))]
        public int fiClient { get; set; }

        [Required]
        public int fiAdmin { get; set; }

        [ForeignKey(typeof(Ticket))]
        public int fiTicket { get; set; }

        public bool isAdmin { get; set; }

        public DateTime createTS { get; set; }

        public DateTime modifyTS { get; set; }
    }
}