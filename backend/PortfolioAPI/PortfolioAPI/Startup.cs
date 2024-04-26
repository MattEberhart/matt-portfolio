using CloudProviders.StorageProviders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
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
        Configuration.GetSection(ConfigurationConstants.AzureTableStorageProviderSettings).Bind(azureStorageProviderSettings);
        services.AddSingleton<AzureStorageProviderSettings>(azureStorageProviderSettings);
        services.AddSingleton<ITableProviderFactory, AzureTableProviderFactory>();
        
        services.AddSingleton<IProjectsRepository, ProjectsRepositoryV2>();

        services.AddControllers();
        
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portfolio API", Version = "v1" });
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

        app.UseCors("AllowAll");
        
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portfolio API V1");
        });
    }
}