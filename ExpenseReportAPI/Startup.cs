using ExpenseReportAPI.Repositories.IRepositories;
using ExpenseReportAPI.Repositories;
using ExpenseReportAPI.Services.IServices;
using ExpenseReportAPI.Services;
using ExpenseReportAPI.Models;
using Microsoft.Extensions.Options;

namespace ExpenseReportAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection Services)
        {
            Services.AddControllers();
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();

            Services.AddScoped<IExpenseReportMasterService, ExpenseReportMasterService>();
            Services.AddScoped<IExpenseReportMasterRepository, ExpenseReportMasterRepository>();

            Services.Configure<AppSettings>(
                Configuration.GetSection(nameof(AppSettings)));

            Services.AddSingleton<IAppSettings>(sp =>
            sp.GetRequiredService<IOptions<AppSettings>>().Value);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }
    }
}
