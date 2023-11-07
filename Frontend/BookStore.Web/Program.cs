using BookStore.Web.Services;
using BookStore.Web.Services.Interface;
using BookStore.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Injecting the httpclient for the service
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

//Configuring the http service
builder.Services.AddHttpClient<IBookService, BookService>();
//builder.Services.AddHttpClient<IAuthser>
//Configuring the base path of the API url link
SD.BookAPIBase = builder.Configuration["ServiceUrls:BookAPI"];
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];

//Configure the book services
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ITokenService, TokenService>();

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
