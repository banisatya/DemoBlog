using DemoBlog.DataAccess.EntityModel;
using System.Data.Entity;
namespace DemoBlog.DataAccess
{
    public partial class DemoContext : DbContext
    {
        //public DemoContext(string connStr)
        //    : base(connStr)
        //{
        //    this.Configuration.LazyLoadingEnabled = false;
        //}
        public DemoContext()
            : base()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<BlogUser> BlogUser { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .Property(e => e.UserName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<User>()
            //    .Property(e => e.Password)
            //    .IsUnicode(false);
            modelBuilder.Entity<BlogUser>().ToTable("dbo.BlogUser");
            modelBuilder.Entity<Blog>().ToTable("dbo.Blog");
            modelBuilder.Entity<Comment>().ToTable("dbo.Comment");
            base.OnModelCreating(modelBuilder);
        }
    }
}
