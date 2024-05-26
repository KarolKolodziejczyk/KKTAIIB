using BibliotekaKlasDAL;
using BibliotekaKlasModel;
using BLL;
using BLL_EF;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebshopContext>();

            builder.Services.AddScoped<OrderBLL, OrderService>(); 
            builder.Services.AddScoped<BasketPostionBLL, Basket>();
            builder.Services.AddScoped<ProductService>();

            // Add services to the container.

            builder.Services.AddControllers();
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