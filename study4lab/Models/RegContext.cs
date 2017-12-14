using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using study4lab.Models;

namespace study4lab.Models
{
    public class RegContext : DbContext
    {
        public RegContext() : base("DefaultConnection") { }
        public DbSet<Reg> Regs { get; set; }
    }
}