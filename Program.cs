using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Allow CORS
builder.Services.AddCors(options => options.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// DI
builder.Services.AddScoped<IImageConverter, ImageConvertor>();
builder.Services.AddScoped<IImageEncodingService, ImageEncodingService>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 524288000; // Set to 500 MB (in bytes)
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 524288000; // Set to 500 MB
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Image Convertor API",
        Description = "This is .NET 8 Web API to convert image format from and to different extensions that includes " +
        "jpg, png, jpeg, webp, tiff, gif and bmp.",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Muhammad Ahmed Villa Khan",
            Url = new Uri("https://github.com/m-ahmedk")
        }
    });

    //options.SchemaFilter<SwaggerSchemaFilter>();
});


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) // Allow Swagger in both environments
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ImageConvertorAPI v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();