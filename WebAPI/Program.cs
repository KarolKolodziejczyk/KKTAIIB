using BibliotekaKlasDAL;
using BibliotekaKlasModel;
using BLL;
using BLL_EF;
using Microsoft.AspNetCore.Cors;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebshopContext>();

            builder.Services.AddScoped<OrderS>(); 
            builder.Services.AddScoped<Basket>();
            builder.Services.AddScoped<ProductService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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
