using AmonsisTestCase.Models.Dapper;
using AmonsisTestCase.Repositories.ReportRepositories;
using AmonsisTestCase.Repositories.UserRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Db baðlantýsý için 
builder.Services.AddTransient<Context>();

// IUserRepository türünde hizmet talep edilirse UserRepository'nin örneðini oluþturuyor
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
