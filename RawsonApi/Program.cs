using Infraestructure.Core.Data;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using RawsonApi.Domain.Services;
using RawsonApi.Domain.Services.Interface;
using Microsoft.Extensions.Hosting;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Context SQL Server
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"));

});
#endregion



#region Inyeccion Dependencia
// Infrastructure
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<SeedDb>();


//Agregamos los Repositorios creados Domain
builder.Services.AddTransient<IPersonaServices, PersonaServices>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
SeedDatabase();
app.Run();
#region Configuracion Data Semmilla RunSeeding
void SeedDatabase() {

    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetService<SeedDb>();
        seeder!.ExecSeedAsync().Wait();
    }

}

#endregion

