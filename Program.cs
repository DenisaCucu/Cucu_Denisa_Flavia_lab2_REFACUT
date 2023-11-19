using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cucu_Denisa_Flavia_lab2_REFACUT.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
});
builder.Services.AddDbContext<Cucu_Denisa_Flavia_lab2_REFACUTContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cucu_Denisa_Flavia_lab2_REFACUTContext") ?? throw new InvalidOperationException("Connection string 'Cucu_Denisa_Flavia_lab2_REFACUTContext' not found.")));
builder.Services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Cucu_Denisa_Flavia_lab2_REFACUTContext") ?? throw new InvalidOperationException("Connectionstring 'Cucu_Denisa_Flavia_lab2_REFACUTContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>(); 
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
