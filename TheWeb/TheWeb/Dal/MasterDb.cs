using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TheWeb.Models;
namespace TheWeb.Dal
{
    public class MasterDb : DbContext
    {

        public DbSet<project> projects { get; set; }
        public DbSet<student> students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}