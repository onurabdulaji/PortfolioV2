using Microsoft.OpenApi.Models;
using PortfolioV2.Application.Extensions;
using PortfolioV2.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Persistence Layer
builder.Services.AddDatabaseExtension(builder.Configuration);
builder.Services.AddGenericPatternExtension();
builder.Services.AddUnitOfWorkExtension();
#endregion

#region Application Layer
builder.Services.AddMapsterExtension();
builder.Services.AddServicesExtension();
builder.Services.AddMediatorExtension();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Portfolio API",
        Version = "v1",
        Description = "API documentation for the Portfolio project.",
        Contact = new OpenApiContact
        {
            Name = "Onur Abdulaji",
            Email = "onurabdulaji@gmail.com",
            Url = new Uri("https://your-website.com")
        }
    });
    options.EnableAnnotations();
});

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
