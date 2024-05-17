using Serilog;
using Serilog.Events;
using Task.Web.Models.Dbcontext;
using Task.Web.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hbc, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .ReadFrom.Configuration(builder.Configuration));

try
{
    // Add services to the container.
    builder.Services.AddScoped<ICustomerService, CustomerService>();
    builder.Services.AddScoped<IMeetingMasterService, MeetingMasterService>();
    builder.Services.AddScoped<IPSService, PSService>();
    builder.Services.AddDbContext<DbContextClass>();
    builder.Services.AddControllersWithViews();

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
    Log.Information("Application is starting...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application can not start.");
}
finally
{
    Log.CloseAndFlush();
}
