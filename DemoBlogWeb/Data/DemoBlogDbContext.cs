using DemoBlogWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlogWeb.Data
{
    public class DemoBlogDbContext : DbContext
    {
        public DemoBlogDbContext(DbContextOptions<DemoBlogDbContext> options) : base(options)
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        
    }
}
