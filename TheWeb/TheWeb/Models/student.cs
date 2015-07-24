using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheWeb.Models
{
    public class student
    {

       [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int IDstudent { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Bebirthday { get; set; }
        public string local { get; set; }
        public int Years { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }


    }
}