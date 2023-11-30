namespace EfCoreCompareSample;

using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<MyEntity> MyEntities { get; set; } = null!;


    public DatabaseContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=test-db;Trusted_Connection=True;Integrated Security=True");
}
