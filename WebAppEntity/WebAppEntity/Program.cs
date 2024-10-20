using EntityDAL.DAL.DBContext;
using EntityDAL.DAL.Repositories.Contratos;
using EntityDAL.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using EntityBLL.BLL;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


//Se encarga de registrar el contexto de base de datos (DBDProductos) en el contenedor de servicios de ASP.NET Core.
// Configura el DbContext utilizando la cadena de conexi�n desde appsettings.json es para la ejecuci�n normal de la aplicaci�n
builder.Services.AddDbContext<DBDProductos>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("EntityDAL"))); // Cambia el nombre de ensamblado si es necesario


// A�adir servicios para controlar los productos
builder.Services.AddScoped<IProductoRepository, ProductoRepository>(); // Aseg�rate de tener esta l�nea para el repositorio
builder.Services.AddScoped<IProductoService, ProductoService>();// Aseg�rate de tener esta l�nea para el servicio


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline HTTP aqu�
app.UseAuthorization();
// Configurar el pipeline HTTP aqu� (si es necesario)
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();
