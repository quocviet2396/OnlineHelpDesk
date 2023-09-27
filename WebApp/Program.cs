using WebApp.Database_helper;
using WebApp.Repositories;
using WebApp.Services;
using WebApp.Ultils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


// Add DI
builder.Services.AddScoped<IAuthenService, AuthenServiceImp>();
builder.Services.AddScoped<ITicketStatusServices, TicketStatusServicesImp>();
builder.Services.AddScoped<IDataService, DataServiceImp>();
builder.Services.AddScoped<IAccountService, AccountServiceImp>();
builder.Services.AddScoped<ITicket, TicketServiceImp>();
builder.Services.AddScoped<Helper>();
builder.Services.AddScoped<Mailultil>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
