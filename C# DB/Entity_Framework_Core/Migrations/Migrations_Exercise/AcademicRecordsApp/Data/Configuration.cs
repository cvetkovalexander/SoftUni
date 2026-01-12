using Microsoft.Extensions.Configuration;

namespace AcademicRecordsApp.Data;

public static class Configuration
{
    private const string DefaultConnectionString = 
        "Server=localhost\\SQLEXPRESS;Database=AcademicRecordsDB;Trusted_Connection=True;Encrypt=False";

    public static string GetConnectionString() 
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<StartUp>()
            .Build();

        IConfigurationProvider secretsProvider = config.Providers.First();
        secretsProvider.
            TryGet("DefaultConnection_NoEncrypt", out string? connectionString);

        return connectionString ?? DefaultConnectionString;
    }
}
