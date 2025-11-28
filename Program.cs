using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Quickunlocker.Web.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();


builder.Services.AddRazorPages();
builder.Services.AddControllers(); // <-- Add this!


builder.Services.AddDbContext<DevicesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Device API", Version = "v1" });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers(); // <-- Add this!


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
