using BlazorAppDemo.Auth;
using BlazorAppDemo.Data;
using BlazorAppDemo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContextFactory<BookContext>(opt => opt.UseSqlServer(ConfigHelper.Configuration["ConnectionStrings:BookContext"]));

// ע��ImitateAuthStateProvider
builder.Services.AddScoped<ImitateAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(implementationFactory => implementationFactory.GetRequiredService<ImitateAuthStateProvider>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// ���ݳ�ʼ��
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        Console.WriteLine("���ݿ⿪ʼ��ʼ��...");
        var context = services.GetRequiredService<BookContext>();
        context.Database.Migrate();
        SeedData.Initialize(services);
        Console.WriteLine("���ݿ��ʼ������!");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "���ݿ��ʼ�����󣡣���");
    }
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
