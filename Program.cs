using AddressProvider.Data.Contexts;
using AddressProvider.Interfaces;
using AddressProvider.Repositories;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddDbContext<Context>(x => x.UseSqlServer(Environment.GetEnvironmentVariable("SqlServerAddress")));
        services.AddScoped<IAddressRepository, AddressRepository>();
    })
    .Build();

host.Run();
