using OCCUWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace OCCUWebsite.Data;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<StatusReport> StatusReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable(nameof(Person));
        modelBuilder.Entity<StatusReport>().ToTable(nameof(StatusReport));
    }
}
