
using Alexandria.Data;
using Alexandria.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Alexandria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<AuthorsRepository>();
            builder.Services.AddScoped<BooksRepository>();
            builder.Services.AddDbContext<AlexandriaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Заполнение БД
            //using (var scope = app.Services.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<AlexandriaDbContext>();
            //    AlexandriaDbContext.Fill(context);
            //}

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
