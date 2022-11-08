using Microsoft.EntityFrameworkCore;

namespace Hostlify.Infraestructure.Context;

public class HostlifyDB:DbContext
{
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Room> Rooms { get; set; }

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
        
        //builder.Entity<Guest>().ToTable("Guest");
        //builder.Entity<Guest>().HasKey(p => p.Id);
        //builder.Entity<Guest>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //builder.Entity<Guest>().Property(p => p.Name).IsRequired().HasMaxLength(15);
        //builder.Entity<Guest>().Property(p => p.Password).IsRequired().HasMaxLength(15);
        //builder.Entity<Guest>().Property(p => p.Lastname).IsRequired().HasMaxLength(15);
        //builder.Entity<Guest>().Property(p => p.Phone).IsRequired();
        //builder.Entity<Guest>().Property(p => p.Mail).IsRequired();


        builder.Entity<Room>().ToTable("Rooms");
        builder.Entity<Room>().HasKey(p => p.Id);
        builder.Entity<Room>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Room>().Property(p => p.Name).IsRequired().HasMaxLength(15);
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

    }
  
    



    
}