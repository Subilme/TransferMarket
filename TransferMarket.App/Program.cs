using Microsoft.EntityFrameworkCore;
using TransferMarket.App.Services;
using TransferMarket.App.Services.Impl;
using TransferMarket.Data;

namespace TransferMarket.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Repositories

            builder.Services.AddScoped<ITeamRepository, TeamRepository>();
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<ICardRepository, CardRepository>();

            #endregion

            #region Configure EF DbContext

            builder.Services.AddDbContext<TransferMarketDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["Settings:DatabaseOptions:ConnectionString"]);
            });

            #endregion

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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