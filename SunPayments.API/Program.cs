using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using Serilog.Core;
using SunPayments.API.Configurations;
using SunPayments.API.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .InstallService(
    builder.Configuration,typeof(IServiceInstaller).Assembly);

Logger log = new LoggerConfiguration()
     .WriteTo.File("logs/log.txt")
     .Enrich.FromLogContext()
     .MinimumLevel.Information()
     .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Bu middleware aþaðýdaki middlewarelarýn'da loglanmasý için en üste konuldu.(_logger.LogInformation vs çalýþmasý için lazým)

app.UseSerilogRequestLogging();

app.UseHttpLogging();

// Ýlk önce exception metoduna girsin. Yukarýdaki if bloðuna alabilirsin.

app.UseCustomException();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
