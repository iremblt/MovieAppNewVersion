using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.Business.Concrete;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories;
using MovieAppNewVersion.Mapping;
using MovieAppNewVersion.Middleware;

namespace MovieAppNewVersion
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
            services.AddDbContext<MovieContext>();
            services.AddScoped<ICastRepository, EfCastRepository>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<ICrewRepository, EfCrewRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IPersonRepository, EfPersonRepository>();
            services.AddScoped<IMovieRepository, EfMovieRepository>();
            services.AddScoped<IVoteRepoistory, EfVoteRepository>();
            services.AddScoped<ICastService, CastManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ICrewService, CrewManager>();
            services.AddScoped<IPersonService, PersonManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IMovieService, MovieManager>();
            services.AddScoped<IVoteService, VoteManager>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            { 
                app.UseDeveloperExceptionPage();
                DataSeeding.Seed(app);

            }
            app.UseStaticFiles();
            app.UseRequestResponse();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
