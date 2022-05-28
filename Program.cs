using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PdfService.Models;
using PdfService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// please see in readMe file about this group of lines
builder.Services.Configure<PdfCvItemsStoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(PdfCvItemsStoreDatabaseSettings)));
builder.Services.AddSingleton<IPdfCvItemsStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<PdfCvItemsStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("PdfCvItemsStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IPdf_Cv_Items_Service, Pdf_Cv_Items_Service>();

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
