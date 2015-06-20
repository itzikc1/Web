using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace TheWeb.Models
{
    public class project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int IDproject { get; set; }
        public int NameProject { get; set; }
        public DateTime deadlineToFinish { get; set; }
        public string local { get; set; }
        public string AboutTheProject { get; set; }
        public string emailContact { get; set; }


    }
}