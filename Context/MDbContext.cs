using ApiMotorFila.Domain;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ApiMotorFila.Context;

public class MDbContext : DbContext
{
    public MDbContext(DbContextOptions<MDbContext> options) : base(options)
    {
    }

    public DbSet<Motor> Motors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = "containers-us-west-156.railway.app",
            Port = 6657,
            Database = "railway",
            Username = "postgres",
            Password = "WTlJ5NgSbYLWxAQMZRQy",
        };

        string connectionString = builder.ConnectionString;

        optionsBuilder.UseNpgsql(connectionString);
    }
}
