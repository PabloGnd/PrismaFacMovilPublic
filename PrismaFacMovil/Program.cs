using PrismaFacMovil.Servicios;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddProgressiveWebApp();
builder.Services.AddScoped<IClienteApi, ClienteApi>();
builder.Services.AddScoped<IRegistroApi, RegistroApi>();
builder.Services.AddScoped<IProductoApi, ProductoApi>();
builder.Services.AddScoped<IFacturaApi, FacturaApi>();
builder.Services.AddScoped<IPerfilApi, PerfilApi>();
builder.Services.AddScoped<INotificacionApi, NotificacionApi>();
builder.Services.AddScoped<IRecargaApi, RecargaApi>();
builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Registro}/{action=Index}");

app.Run();
