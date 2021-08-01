using DalInfraContracts;
using GamePlatformDictValue;
using GamePlatformServiceImpl;
using GameServiceImpl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PlayersImpl;
using RandomPlayerImpl;
using ScanPlayerImpl;
using SQLInfraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UserServiceImpl;
using XOBoardMatImpl;
using XOBoardService;
using XOContracts;
using XOPlayersContracts;
using XOServerContracts;

namespace XOAppWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // board
            services.AddTransient<IXOBoard, XOBoard>();
            services.AddTransient<IXOBoardService, XOBoardServiceImpl>();
            // players
            services.AddTransient<IRandomPlayer, RandomPlayer>();
            services.AddTransient<IScanPlayer,ScanPlayer>();
            services.AddTransient<IPlayersService, PlayersService>();
            // game
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGameValue, GameValue>();
            services.AddSingleton<IGamePlatformService, GamePlatformService>();
            // DAL
            services.AddTransient<IDAL, DAL>();


            services.AddControllers();
            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add
          (new JsonStringEnumConverter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
