using CloudProviders.StorageProviders;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Repositories;

namespace PortfolioAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var azureStorageProviderSettings = new AzureStorageProviderSettings();
        Configuration.GetSection(ConfigurationConstants.AzureStorageProviderSettings).Bind(azureStorageProviderSettings);
        services.AddSingleton<AzureStorageProviderSettings>(azureStorageProviderSettings);
        services.AddSingleton<IStorageProvider, AzureStorageProvider>();
        
        services.AddSingleton<IProjectsRepository, ProjectsRepository>();

        services.AddControllers();
        
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}