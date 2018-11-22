using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Context
{
    public class PlannedMenusContext : DbContext
    {
        public PlannedMenusContext(DbContextOptions<PlannedMenusContext> options) : base(options)
        {

        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCard> MenuCards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MenuCard>().Property(mc => mc.Name).HasMaxLength(50).IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
