using EntityDAL.DAL.DBContext;
using EntityDAL.DAL.Repositories.Contratos;
using EntityDAL.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using EntityBLL.BLL;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


//Se encarga de registrar el contexto de base de datos (DBDProductos) en el contenedor de servicios de ASP.NET Core.
// Configura el DbContext utilizando la cadena de conexión desde appsettings.json es para la ejecución normal de la aplicación
builder.Services.AddDbContext<DBDProductos>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("EntityDAL"))); // Cambia el nombre de ensamblado si es necesario


// Añadir servicios para controlar los productos
builder.Services.AddScoped<IProductoRepository, ProductoRepository>(); // Asegúrate de tener esta línea para el repositorio
builder.Services.AddScoped<IProductoService, ProductoService>();// Asegúrate de tener esta línea para el servicio


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline HTTP aquí
app.UseAuthorization();
// Configurar el pipeline HTTP aquí (si es necesario)
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();
