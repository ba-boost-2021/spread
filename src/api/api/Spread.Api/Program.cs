using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Settings>(builder.Configuration.GetSection(nameof(Settings)));

#region Check Environment
var section = builder.Configuration.GetSection($"{nameof(Settings)}");
var settings = section.Get<Settings>();
Console.WriteLine($"❤️❤️❤️❤️❤️ {settings.Environment} ❤️❤️❤️❤️❤️");
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddData(builder.Configuration)
                .AddDataServices()
                .AddAutoMapper();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Program class'ı zaten var ama Minimal API'dan ötürü adı görünmüyor o sebeple boş bir partial class oluşturduk
public partial class Program { }