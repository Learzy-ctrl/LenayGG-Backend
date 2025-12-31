namespace LGG.LenayGestorGatos.Infraestructure;
public static class DContainer
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        string serviceAccountPath = Environment.GetEnvironmentVariable("FIREBASE_CREDENTIALS");
        //string serviceAccountPath = configuration.GetConnectionString("FirebaseCredentials");
        //var connectionSettingsSection = configuration.GetSection(ConnectionsSettings.SectionName);
        


        var dbConnection = configuration["ConnectionStrings:DbConnection"];

        /*services
        .Configure<ConnectionsSettings>(connectionSettingsSection)
        .AddDbContext<GestorGastosContext>(options =>
        {
            options.UseMySql(configuration.GetConnectionString("DbConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DbConnection")));
        }).AddDbContext<GestorInventariosContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(3600),
                errorNumbersToAdd: null);
                sqlOptions.CommandTimeout(3600);
            });
        });*/

        services
       .Configure<ConnectionsSettings>(configuration.GetSection(ConnectionsSettings.SectionName))
       .AddDbContext<GestorGastosContext>(options =>
       {
           options.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection));
       })
       .AddDbContext<GestorInventariosContext>(options =>
       {
           options.UseSqlServer(dbConnection, sqlOptions =>
           {
               sqlOptions.EnableRetryOnFailure(
                   maxRetryCount: 10,
                   maxRetryDelay: TimeSpan.FromSeconds(3600),
                   errorNumbersToAdd: null);
               sqlOptions.CommandTimeout(3600);
           });
       });

        services.AddSingleton<FirebaseContext>(provider => new FirebaseContext(serviceAccountPath));
        //Add config cors
        //add config JWT

        services.AddScoped<IUnitRepository, UnitRepository>();
        return services;
    }
}
