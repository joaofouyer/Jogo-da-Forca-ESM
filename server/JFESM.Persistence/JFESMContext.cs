using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using JFESM.Model;

namespace JFESM.Persistence
{
    public class JFESMContext : DbContext
    {
        //Use for DataBase example
        // public DbSet<Boneco> Bonecos { get; set; } 

        public JFESMContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}