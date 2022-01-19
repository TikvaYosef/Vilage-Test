using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Vilage.Models
{
    public partial class VilageDataContext : DbContext
    {
        public VilageDataContext()
            : base("name=VilageDataContext")
        {
        }
        public virtual DbSet<Resident> Residents { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
