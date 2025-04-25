using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.Services.Implements.Storage.Local;
using ETicaretAPI.Persistence;

namespace ETicaretAPI.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));
        builder.Services.AddPresentationLayer(builder.Configuration.GetSection("Jwt").Get<Jwt>());
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
        });
        builder.Services.AddOpenApi();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseStaticFiles();
        app.UseCors();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
