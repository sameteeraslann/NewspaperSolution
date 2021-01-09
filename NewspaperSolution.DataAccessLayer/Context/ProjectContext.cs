using NewspaperSolution.EntityLayer.Entites.Concrete;
using NewspaperSolution.MappingLayer.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSolution.DataAccessLayer.Context
{
    public class ProjectContext: DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=DESKTOP-NPT9S1G;Database=NewspaperSolution;Integrated Secrurity=True";
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment>  Comments{ get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new PostMap());

            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));
            // Oluşturduğumuz tipinde ki veriler DataBase de "datetime2" olarak değişecektir.

            base.OnModelCreating(modelBuilder);
        }
    }
}
