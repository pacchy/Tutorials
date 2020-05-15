using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorials.API.Model;

namespace Tutorials.API.DAL
{
    public class TutorialContext : DbContext
    {

        public TutorialContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Tutorials.API.Model.Tutorial> Tutorials { get; set; }
        public DbSet<Topic> Topics { get; set; }

    }
}
