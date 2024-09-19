using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataBookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;

namespace ODataBookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                    .AddOData(options =>
                        options.Select()
                               .Filter()
                               .Count()
                               .OrderBy()
                               .Expand()
                               .SetMaxTop(100)
                               .AddRouteComponents("odata", GetEdmModel()));

            // Add DbContext with In-Memory database.
            builder.Services.AddDbContext<BookStoreContext>(opt =>
                opt.UseInMemoryDatabase("BookLists"));

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        // Define OData model, mapping entities to routes.
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Book>("Books");
            builder.EntitySet<Press>("Presses");
            return builder.GetEdmModel();
        }
    }
}
