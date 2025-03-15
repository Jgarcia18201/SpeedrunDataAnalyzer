using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedrunDataAnalyzer
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TVG7VL8;Initial Catalog=SpeedrunDB;Integrated Security=True;Trust Server Certificate=True");
        }

        public DbSet<RunManager> TimerRuns { get; set; }
    }
}
