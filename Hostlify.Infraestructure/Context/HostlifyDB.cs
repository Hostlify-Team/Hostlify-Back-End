using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure.Context;

public class HostlifyDB:DbContext
{
    public HostlifyDB() //Entity Framework me dice que debo tener constructores
    {
    }
    public HostlifyDB(DbContextOptions<HostlifyDB> options) : base(options) //Entity Framework me dice que debo tener constructores
    {
    }
    
    public DbSet<Plan> Plans { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<History> History { get; set; }
    public DbSet<FoodServices> FoodServices { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) //Aqui valido otra vez si mi BD esta configurado, sino lo vuelvo a configurar 5 Y HACEMOS LA MIGRACION 6 NUGET:Entity framework core tools
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
            optionsBuilder.UseMySql("server=localhost;user=root;password=123456;database=hostlifydb; ",serverVersion);
        }
    }
    
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Plan>().ToTable("Plans");
        builder.Entity<Plan>().HasKey(p => p.Id);
        builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(p => p.Name).IsRequired().HasMaxLength(15);
        builder.Entity<Plan>().Property(p => p.Rooms).HasDefaultValue(null);
        builder.Entity<Plan>().Property(p => p.Price).IsRequired();
        builder.Entity<Plan>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Plan>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(c => c.Name).IsRequired();
        builder.Entity<User>().Property(c => c.Password).IsRequired();
        builder.Entity<User>().Property(c => c.Email).IsRequired();
        builder.Entity<User>().Property(c => c.Plan).HasDefaultValue(null);
        builder.Entity<User>().Property(c => c.Type).IsRequired();
        builder.Entity<User>().Property(c => c.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Entity<User>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
        
        builder.Entity<Room>().ToTable("Rooms");
        builder.Entity<Room>().HasKey(p => p.Id);
        builder.Entity<Room>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Room>().Property(p => p.RoomName).IsRequired().HasMaxLength(15);
        builder.Entity<Room>().Property(p => p.GuestId);
        builder.Entity<Room>().Property(p => p.ManagerId).IsRequired();
        builder.Entity<Room>().Property(p => p.Initialdate);
        builder.Entity<Room>().Property(p => p.EndDate);
        builder.Entity<Room>().Property(p => p.Status).IsRequired().HasDefaultValue(true);
        builder.Entity<Room>().Property(p => p.GuestStayComplete);
        builder.Entity<Room>().Property(p => p.Price);
        builder.Entity<Room>().Property(p => p.Image);
        builder.Entity<Room>().Property(p => p.Description).HasMaxLength(999);
        builder.Entity<Room>().Property(p => p.Emergency).IsRequired().HasDefaultValue(false);
        builder.Entity<Room>().Property(p => p.ServicePending).IsRequired().HasDefaultValue(false);
        builder.Entity<Room>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Room>().Property(p => p.IsActive).HasDefaultValue(true);
        
        builder.Entity<History>().ToTable("History");
        builder.Entity<History>().HasKey(p => p.id);
        builder.Entity<History>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<History>().Property(p => p.roomName).IsRequired().HasMaxLength(15);
        builder.Entity<History>().Property(p => p.managerId).IsRequired();
        builder.Entity<History>().Property(p => p.guestName).IsRequired();
        builder.Entity<History>().Property(p => p.initialDate).IsRequired();
        builder.Entity<History>().Property(p => p.endDate).IsRequired();
        builder.Entity<History>().Property(p => p.price).IsRequired();
        builder.Entity<History>().Property(p => p.description);
        builder.Entity<History>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<History>().Property(p => p.IsActive).HasDefaultValue(true);
        
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