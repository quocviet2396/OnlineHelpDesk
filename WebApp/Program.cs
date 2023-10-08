using WebApp.Database_helper;
using WebApp.Repositories;
using WebApp.Services;
using WebApp.Signal;
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
builder.Services.AddSignalR();


// Add DI
builder.Services.AddScoped<IAuthenService, AuthenServiceImp>();
builder.Services.AddScoped<ITicketStatusServices, TicketStatusServicesImp>();
builder.Services.AddScoped<IPriorityServices, PriorityServicesImp>();
builder.Services.AddScoped<IFacilitiesServices, FacilitiesServiceImp>();
builder.Services.AddScoped<IDataService, DataServiceImp>();
builder.Services.AddScoped<IAccountService, AccountServiceImp>();
builder.Services.AddScoped<ITicket, TicketServiceImp>();
builder.Services.AddScoped<INewsService, NewsServiceImp>();
builder.Services.AddScoped<INotificationService, NotificationServiceImp>();
builder.Services.AddScoped<IQnAService, QnAServiceImp>();
builder.Services.AddScoped<Helper>();
builder.Services.AddScoped<Mailultil>();
builder.Services.AddScoped<SignalConfig>();


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

app.MapHub<SignalConfig>("/Notification");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Frontend}/{action=Index}/{id?}");


app.Run();
