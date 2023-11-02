using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Persistence;

public class DatabaseContext: DbContext {

    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options){

    }

    public DbSet<Person> Persons {set; get;}

    public DbSet<Contract> Contracts {set; get;}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Person>(table => {
            table.HasKey(key => key.id);
            table.HasMany(key => key.contracts).WithOne().HasForeignKey(key => key.person_id);
        });

        modelBuilder.Entity<Contract>(table => {
            table.HasKey(key => key.id);
        });
    }

}