using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace taskToAutomat
{
    internal class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CK5JL4S;Initial Catalog=samplesForTest;Integrated Security=True");
        }

        public DbSet<samplesFromDB> samples { get; set; } = null;
    }

    public class samplesFromDB
    {
        [Key]
        public int id { get; set; }
        public int idParametr { get; set; }
        public string Samples { get; set; }
        public string TrueSamples { get; set; }

    }
}
