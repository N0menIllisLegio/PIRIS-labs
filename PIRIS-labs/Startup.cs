using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PIRIS_labs.Data;
using PIRIS_labs.Helpers;
using PIRIS_labs.Services;

namespace PIRIS_labs
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseLazyLoadingProxies()
            .UseSqlServer(Configuration.GetConnectionString("LocalDB")));

      services.AddRazorPages();
      services.AddServerSideBlazor();
      services.AddDatabaseDeveloperPageExceptionFilter();

      services.AddAutoMapper(typeof(AutoMapperProfile));

      services.AddSingleton<DateService>();

      services.AddScoped<UnitOfWork>();
      services.AddScoped<ClientsService>();
      services.AddScoped<CitiesService>();
      services.AddScoped<DisabilitiesService>();
      services.AddScoped<NationalitiesService>();
      services.AddScoped<MaritalStatusesService>();
      services.AddScoped<DepositPlansService>();
      services.AddScoped<DepositsService>();
      services.AddScoped<AccountsService>();
      services.AddScoped<TransactionsService>();
      services.AddScoped<BankOperationsService>();
      services.AddScoped<CreditPlansService>();
      services.AddScoped<CreditsService>();
      services.AddScoped<CreditCardsService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory serviceScopeFactory)
    {
      using (var scope = serviceScopeFactory.CreateScope())
      {
        var appDbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
        appDbContext.Database.Migrate();
      }

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseMigrationsEndPoint();
        app.UseBrowserLink();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToPage("/_Host");
      });
    }
  }
}