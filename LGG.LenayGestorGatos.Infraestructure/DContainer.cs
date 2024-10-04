namespace LGG.LenayGestorGatos.Infraestructure;
public static class DContainer
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
    {        

        var connectionSettingsSection = configuration.GetSection(ConnectionsSettings.SectionName);
        var connectionSettings = connectionSettingsSection.Get<ConnectionsSettings>();
        string serviceAccountPath = "Config/lenay-gestor-de-gastos-firebase-adminsdk-ulqms-00ed09bb90.json";

        services
        .Configure<ConnectionsSettings>(connectionSettingsSection)
        .AddDbContext<GestorGastosContext>(options =>
        {
            options.UseMySql(configuration.GetConnectionString("DbConnection"), new MySqlServerVersion(new Version(8, 0, 0)));
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
        });

        services.AddSingleton<FirebaseContext>(provider => new FirebaseContext(serviceAccountPath));
        //Add config cors
        //add config JWT

        services.AddScoped<IUnitRepository, UnitRepository>();
        return services;
    }
}
