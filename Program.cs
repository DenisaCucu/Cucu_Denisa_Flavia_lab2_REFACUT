using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cucu_Denisa_Flavia_lab2_REFACUT.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Cucu_Denisa_Flavia_lab2_REFACUTContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cucu_Denisa_Flavia_lab2_REFACUTContext") ?? throw new InvalidOperationException("Connection string 'Cucu_Denisa_Flavia_lab2_REFACUTContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
