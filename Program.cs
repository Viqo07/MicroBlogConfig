
using MicroBlog.Services;
using MicroBlog.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Configure SiteOptions using appsettings.json
builder.Services.Configure<SiteOptions>(
    builder.Configuration.GetSection("SiteOptions"));

// Use the JSON repository.
builder.Services.AddSingleton<IBlogRepository, JsonBlogRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
