﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheWeb.Models
{
    public class student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int IDstudent { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Bebirthday { get; set; }

    }
}