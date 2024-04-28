using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ShoppingCartEmailService.Services;
using ShoppingCartEmailService.Settings;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//IConfigurationRoot configuration = new ConfigurationBuilder()
//            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//            .AddJsonFile("appsettings.json")
//            .Build();
//optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddEndpointsApiExplorer();
//builder.Services.Configure<MailSettings>(("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();
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
