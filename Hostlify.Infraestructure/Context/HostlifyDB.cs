using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hostlify.Infraestructure.Context;

public class HostlifyDB:DbContext
{
    public DbSet<Plan> Plans { get; set; }

    public DbSet<History> History { get; set; }

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


    }
}