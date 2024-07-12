
using Test_task.Models;
using Test_task.Service.DbServices;
using Test_task.Service.UserService;
using Test_task.Service.UserServices;

namespace Test_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext <ApplicationDbContext>();

            builder.Services.AddScoped<IUserDbService, UserDbService>();
            builder.Services.AddScoped<IChatDbService, ChatDbService>();

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IChatService, ChatService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
