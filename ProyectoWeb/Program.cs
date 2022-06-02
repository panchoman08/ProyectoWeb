using ProyectoWeb;
using ProyectoWeb.Providers.APiFerreteria.product;
using ProyectoWeb.Providers.APiFerreteria.product_measure;
using ProyectoWeb.Providers.APiFerreteria.product_state;
using ProyectoWeb.Providers.APiFerreteria.supplier;
using ProyectoWeb.Providers.APiFerreteria.supplier_category;
using ProyectoWeb.Repository.CustomerCatRepositories;
using ProyectoWeb.Repository.CustomerRepositories;
using ProyectoWeb.Repository.ProductCatRepositories;
using ProyectoWeb.Repository.ProductMeasureRepository;
using ProyectoWeb.Repository.ProductRepository;
using ProyectoWeb.Repository.SupplierCatRepositories;
using ProyectoWeb.Repository.SupplierRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddTransient<ProductProvider>();
builder.Services.AddTransient<ProductMeasureProvider>();
builder.Services.AddTransient<ProductCatProvider>();
builder.Services.AddTransient<SupplierProvider>();
builder.Services.AddTransient<SupplierCatProvider>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductMeasureRepository, ProductMeasureRepository>();
builder.Services.AddTransient<IProductCatRepository, ProductCatRepository>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddTransient<ISupplierCatRepository, SupplierCatRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerCatRepository, CustomerCatRepository>();


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
/*
var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);


var app = builder.Build();
startup.Configure(app, app.Environment);
// Add services to the container.


app.Run();*/
