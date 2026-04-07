using DemoElasticKibana.ElasticSearch;
using DemoElasticKibana.Models;
using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Elasticsearch;
using Serilog;
using System.Reflection;

namespace DemoElasticKibana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Add configs
            builder.Services.Configure<AppSetting>(builder.Configuration);
            // Add elastic search
            builder.Services.AddElasticSearch(builder.Configuration);
            builder.Services.AddSingleton(typeof(IElasticSeachService<>), typeof(ElasticSearchService<>));

            // Cấu hình Serilog
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()  // Ghi log ra console
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true,  // Tự động tạo template trong Elasticsearch
                    IndexFormat = $"applogs-{Assembly.GetExecutingAssembly().GetName().Name?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                    // Đặt tên index theo format "applogs-tên-ứng-dụng-tháng"
                    NumberOfReplicas = 1,  // Cấu hình replica của index
                    NumberOfShards = 2     // Số shards của index
                })
                .Enrich.WithProperty("Environment", builder.Environment.EnvironmentName)  // Thêm thuộc tính môi trường
                .Enrich.WithProperty("Application", Assembly.GetExecutingAssembly().GetName().Name)  // Thêm thuộc tính ứng dụng
                .ReadFrom.Configuration(builder.Configuration)  // Đọc cấu hình từ appsettings.json
                .CreateLogger();

            builder.Host.UseSerilog();

            var app = builder.Build();

          // Sử dụng Serilog cho ASP.NET Core
            app.Use(async (context, next) =>
            {
                var requestTime = DateTime.UtcNow;
                // Đọc request body
                context.Request.EnableBuffering();
                var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0; // Reset stream về đầu để tiếp tục xử lý request

                // Ghi đè response body để có thể đọc nó sau khi response hoàn tất
                var originalBodyStream = context.Response.Body;
                using var responseBody = new MemoryStream();
                context.Response.Body = responseBody;

                // Gọi tiếp đến middleware tiếp theo trong pipeline
                await next.Invoke();

                // Ghi lại thời gian kết thúc request
                var responseTime = DateTime.UtcNow;

                // Đọc response body
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                // Log thông tin request và response
                Log.Information("Request in {Duration}ms\nRequest: {RequestBody}\nResponse: {ResponseBody}",
                    //context.Request.Method,
                    //context.Request.Path,
                    //context.Response.StatusCode,
                    (responseTime - requestTime).TotalMilliseconds,
                    requestBody,
                    responseText);

                // Ghi response ra stream thực tế để trả về client
                await responseBody.CopyToAsync(originalBodyStream);
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
