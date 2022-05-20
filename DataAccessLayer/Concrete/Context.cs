using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-BUBEBSC; database=DbPetCare;integrated security=true");
            //optionsBuilder.UseSqlServer("Data Source=77.245.159.136;Initial Catalog=veteriner;User ID=veteriner;Password=A.sd12345678987654321;persist security info=True");
        }

        public DbSet<Feature> Features { get; set; }
        public DbSet<FeaturedBox> FeaturedBoxes { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WorkingHour> WorkingHours { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Contact> Contacts { get; set; }




    }
}
