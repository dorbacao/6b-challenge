using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

/// <summary>
/// Data Context to persistence data on this project, for a while using a single bounded context
/// </summary>
public class BookingDataContext : DbContext
{
    private readonly ILoggerFactory loggerFactory;
    private readonly IConfiguration _configuration;

    public BookingDataContext(DbContextOptions<BookingDataContext> options, ILoggerFactory loggerFactory, IConfiguration configuration) : base(options)
    {
        this.loggerFactory = loggerFactory;
        _configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        if (Debugger.IsAttached && this.loggerFactory != null)
        {
            //Quando a depuração está anexada ao processo, então configura o log provider no EF core para facilitar depuração
            optionsBuilder.UseLoggerFactory(this.loggerFactory);
        }

        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserTypeConfiguration());

        Seed.Fill(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }


}
