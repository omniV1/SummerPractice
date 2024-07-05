using Microsoft.EntityFrameworkCore;
using AircraftMaintenanceAPI.Data;
using AircraftMaintenanceAPI.Middleware;  // Add this line

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AircraftMaintenanceContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();  // Add this line

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
