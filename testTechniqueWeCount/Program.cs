using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using testTechniqueWeCount.Data;
using testTechniqueWeCount.Models;
using testTechniqueWeCount.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MainConnection")
    ));
builder.Services.AddDbContext<IdentityAppContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MainConnection")
    ));
builder.Services.AddIdentity<Administrateur, IdentityRole>()
    .AddEntityFrameworkStores<IdentityAppContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ICandidatureService,CandidatureService>();
builder.Services.AddScoped<ICvuploadService, CvuploadService>();
builder.Services.AddScoped<IEmailService, EmailService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Candidature}/{action=Create}/{id?}");

app.Run();
