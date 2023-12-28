
using ExpenseReportAPI.Repositories;
using ExpenseReportAPI.Repositories.IRepositories;
using ExpenseReportAPI.Services;
using ExpenseReportAPI.Services.IServices;
using Microsoft.AspNetCore;

namespace ExpenseReportAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}