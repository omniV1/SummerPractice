using Microsoft.EntityFrameworkCore;
using AircraftMaintenanceAPI.Data;
using AircraftMaintenanceAPI.Middleware;
using AircraftMaintenanceAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AircraftMaintenanceContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

// Add the service registrations
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAircraftService, AircraftService>();
builder.Services.AddScoped<IMaintenanceRecordService, MaintenanceRecordService>();
builder.Services.AddScoped<IPerformanceMetricService, PerformanceMetricService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if (response.StatusCode == 400 && context.HttpContext.Request.Path.StartsWithSegments("/api"))
    {
        response.ContentType = "application/json";

        await response.WriteAsync(new
        {
            StatusCode = response.StatusCode,
            Message = "Bad Request"
        }.ToString() ?? "");
    }
});

// Enable CORS
app.UseCors("AllowAllOrigins");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
