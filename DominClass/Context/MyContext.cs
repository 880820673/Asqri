using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DominClass.Context
{
    public class MyContext:DbContext
    {
       
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Marketer> Marketers { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Slid> Slid { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Doreh> Doreh { get; set; }
        public DbSet<Listt> Listts { get; set; }
        public DbSet<Nazar> Nazar { get; set; }
    }
}
