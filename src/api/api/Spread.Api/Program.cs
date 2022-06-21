using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Settings>(builder.Configuration.GetSection(nameof(Settings)));

#region Check Environment

var section = builder.Configuration.GetSection($"{nameof(Settings)}");
var settings = section.Get<Settings>();
#endregion Check Environment

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwt(settings)
                .AddData(builder.Configuration)
                .AddDataServices()
                .AddAutoMapper();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(option => { option.AddPolicy(builder.Environment.EnvironmentName, p => { p.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader(); }); });
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
if (builder.Environment.IsDevelopment())
{
    app.UseCors(builder.Environment.EnvironmentName);
}
app.UseAuthentication();
app.UseAuthorization();
app.UseClaims();
app.MapControllers();
app.Run();

// Program class'ı zaten var ama Minimal API'dan ötürü adı görünmüyor o sebeple boş bir partial class oluşturduk
public partial class Program
{ }