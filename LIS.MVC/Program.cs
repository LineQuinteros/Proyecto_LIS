using API_Consumer;
using Modelos_LIS;
using LIS.Servicios.Interfaces;
using LIS.Servicios;

Crud<Medicos>.EndPoint = "https://proyecto-lis-1.onrender.com/api/Medicos";
Crud<Especialidades>.EndPoint = "https://proyecto-lis-1.onrender.com/api/Especialidades";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddAuthentication("Cookies") //cokies
                .AddCookie("Cookies", options =>
                {
                    options.LoginPath = "/Account/Index"; // Ruta de inicio de sesión


                });
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
