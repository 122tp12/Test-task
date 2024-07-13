
using Microsoft.AspNetCore.SignalR;
using Test_task.Models;
using Test_task.Service.DbServices;
using Test_task.Service.UserService;
using Test_task.Service.UserServices;
using Test_task.SignalR;

namespace Test_task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext <ApplicationDbContext>();

            builder.Services.AddScoped<IUserDbService, UserDbService>();
            builder.Services.AddScoped<IChatDbService, ChatDbService>();

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IChatService, ChatService>();

            builder.Services.AddSignalR();

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

            app.MapHub<ComHub>("com-hub");


            app.Run();
        }
    }
}
