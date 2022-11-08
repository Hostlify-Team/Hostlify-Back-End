using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure.Context;

public class HostlifyDB:DbContext
{
    public DbSet<Plan> Plans { get; set; }
    public DbSet<FoodServices> FoodServices { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) //Aqui valido otra vez si mi BD esta configurado, sino lo vuelvo a configurar 5 Y HACEMOS LA MIGRACION 6 NUGET:Entity framework core tools
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
            optionsBuilder.UseMySql("server=localhost;user=root;password=123456;database=hostlifydb; ",serverVersion);
        }
    }
    public HostlifyDB() : base() //Entity Framework me dice que debo tener constructores
    {
      
    }
    public HostlifyDB(DbContextOptions<HostlifyDB> options) : base(options) //Entity Framework me dice que debo tener constructores
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Plan>().ToTable("Plans");
        builder.Entity<Plan>().HasKey(p => p.Id);
        builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(p => p.Name).IsRequired().HasMaxLength(15);
        builder.Entity<Plan>().Property(p => p.Rooms);
        builder.Entity<Plan>().Property(p => p.Price).IsRequired();
        builder.Entity<Plan>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Plan>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<FoodServices>().ToTable("FoodServices");
        builder.Entity<FoodServices>().HasKey(p => p.Id);
        builder.Entity<FoodServices>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FoodServices>().Property(p => p.RoomID).IsRequired();
        builder.Entity<FoodServices>().Property(p => p.ManagerID).IsRequired();
        builder.Entity<FoodServices>().Property(p => p.Dish).IsRequired();                                                          
        builder.Entity<FoodServices>().Property(p => p.DishQuantity).IsRequired();
        builder.Entity<FoodServices>().Property(p => p.Drink).IsRequired();
        builder.Entity<FoodServices>().Property(p => p.DrinkQuantity).IsRequired();
        builder.Entity<FoodServices>().Property(p => p.Cream).IsRequired();
        builder.Entity<FoodServices>().Property(p => p.CreamQuantity).IsRequired();
        builder.Entity<FoodServices>().Property(p => p.Instruction).HasMaxLength(999);
        builder.Entity<FoodServices>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<FoodServices>().Property(p => p.IsActive).HasDefaultValue(true);

    }
}