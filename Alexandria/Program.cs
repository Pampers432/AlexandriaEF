using AlexandriaEF.Abstraction;
using AlexandriaEF.Data;
using AlexandriaEF.Repositories;
using AlexandriaEF.Services;
using Microsoft.EntityFrameworkCore;

namespace AlexandriaEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            builder.Services.AddScoped<IBooksRepository, BooksRepository>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
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
