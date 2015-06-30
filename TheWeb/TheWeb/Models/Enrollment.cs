using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheWeb.Models
{
    public class Enrollment
    {
       [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int EnrollmentID { get; set; }
        public int ProjectID { get; set; }
        public int StudentID { get; set; }

        public virtual project Project { get; set; }
        public virtual student Student { get; set; }
    }
}