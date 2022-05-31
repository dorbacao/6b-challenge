using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class BookingDataContextFactory : IDesignTimeDbContextFactory<BookingDataContext>
{
    private readonly IConfiguration configuration;
    public ILoggerFactory LoggerFactory { get; }

    /// <summary>
    /// This consctructor is used in the runtime application to factory the instance of DataContext
    /// </summary>
    /// <param name="loggerFactory"></param>
    /// <param name="configuration"></param>
    public BookingDataContextFactory(ILoggerFactory loggerFactory, IConfiguration configuration)
    {
        this.LoggerFactory = loggerFactory;
        this.configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
    }

    /// <summary>
    /// This constructor is used to factory BookingDataContextInstance when command line migrations is usecuted
    /// </summary>
    public BookingDataContextFactory()
    {
        configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();
    }


    /// <summary>
    /// Get the current connection string
    /// </summary>
    /// <returns></returns>
    private string GetCurrentConnectionString()
    {
        return configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
    }

    public BookingDataContext CreateDbContext(string[] args)
    {
        var connectionString = GetCurrentConnectionString();

        var optionsBuilder = new DbContextOptionsBuilder<BookingDataContext>();

        optionsBuilder.UseSqlServer(connectionString);

        var context = new BookingDataContext(optionsBuilder.Options, LoggerFactory, configuration);

        return context;

    }
}
