using Helniv_AccessControl.Interfaces;
using Helniv_AccessControl.Service;
using Helniv_AccessControl.Services;
using Helniv_AccessControl.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.ConfigureAuthenticationJWT();

builder.Services.AddControllers().AddJsonOptions(j =>
{
    j.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddDbContext<HelnivDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.ConfigureCors();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<Validation>();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
}); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();