
using Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using simple_merchandise.Context;
using simple_merchandise.Conventions;
using simple_merchandise.Interface;
using simple_merchandise.Repository;
using simple_merchandise.Service;

namespace simple_merchandise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SupplierContext>(options =>
            options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]));

            builder.Services.AddTransient<IGenericRepository, GenericRepository>();
            builder.Services.AddTransient<IContactService, ContactService>();
            builder.Services.AddTransient<ISupplierService, SupplierService>();
            builder.Services.AddTransient<IMerchandiseService, MerchandiseService>();

            builder.Services.AddControllers(options =>
            {
                options.Conventions.Insert(0, new GlobalRoutePrefixConvention("api"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SupplierContext>();
                db.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var error = feature?.Error;

                    context.Response.ContentType = "application/json";

                    if (error is CustomException customEx)
                    {
                        context.Response.StatusCode = customEx.StatusCode;
                        await context.Response.WriteAsJsonAsync(new { error = customEx.Message });
                    }
                    else
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred." });
                    }
                });
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
