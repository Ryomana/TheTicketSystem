using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

// This represents the database table Requests
namespace Umbraco.Core.TheTicketSystem.Objects
{
    [TableName("Requests")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class Requests
    {
        public Requests() { }

        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}