using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TiendaPrcatica.DB;
using TiendaPrcatica.Repository;

var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddTransient<IProductoRepository, ProductRepository>();
    builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
    builder.Services.AddTransient<IAuthRepository, AuthRepository>();
    builder.Services.AddDbContext<DbEntities>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("con")));



// Add services to the container.
builder.Services.AddControllersWithViews();
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
        options =>
        {
            options.LoginPath = "/auth/Login";

        });


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
