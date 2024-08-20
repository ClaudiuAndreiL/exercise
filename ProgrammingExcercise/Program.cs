
using ProgrammingExercise.Features.v1.Services;
using ProgrammingExercise.Features.v2;
using ProgrammingExercise.Features.v3;

namespace ProgrammingExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IAlgoRunnerService, AlgoRunnerService>();

            builder.Services.AddScoped<ITimeProviderService, TimeProviderService>();
            builder.Services.AddScoped<IAlgoRunnerServiceV2, AlgoRunnerServiceV2>();
            builder.Services.AddScoped<IPigLatinService, PigLatinService>();
            builder.Services.AddScoped<IPalindromeService, PalindromeService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
