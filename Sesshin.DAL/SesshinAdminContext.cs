using System.Data.Entity;
using Sesshin.Model;

namespace Sesshin.DAL
{
    public class SesshinAdminContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Sesshin.Admin.Models.SesshinAdminContext>());
        public SesshinAdminContext()
            : base("name=SesshinConn")
        { }
        public DbSet<Product> Products { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<PriceModel> PriceModels { get; set; }
        
        public DbSet<Redirect> Redirects { get; set; }

        public DbSet<BackgroundImage> Images { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Street> Streets { get; set; }

        public DbSet<Therapist> Therapists { get; set; }

        public DbSet<ThreatmentType> ThreatmentTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().
              HasMany(c => c.BackgroundImages).
              WithMany(p => p.Products).
              Map(
               m =>
               {
                   m.MapLeftKey("ProductId");
                   m.MapRightKey("BackgroundImageId");
                   m.ToTable("ProductImages");
               });

            modelBuilder.Entity<Article>().
              HasMany(c => c.BackgroundImages).
              WithMany(p => p.Articles).
              Map(
               m =>
               {
                   m.MapLeftKey("ArticleId");
                   m.MapRightKey("BackgroundImageId");
                   m.ToTable("ArticleImages");
               });

            //modelBuilder.Entity<Therapist>().
            //  HasMany(c => c.ThreatmentTypes).
            //  WithMany(p => p.Therapists).
            //  Map(
            //   m =>
            //   {
            //       m.MapLeftKey("TherapistId");
            //       m.MapRightKey("ThreatmentTypeId");
            //       m.ToTable("TherapistThreatments");
            //   });
        }

       
    }
}