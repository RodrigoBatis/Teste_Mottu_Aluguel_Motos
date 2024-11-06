using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TesteMottu.Data;
using TesteMottu.Repository;
using TesteMottu.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext> (options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"))
        .LogTo(Console.WriteLine, LogLevel.Information)
);

builder.Services.AddScoped<IEntregadorRepository, EntregadorRepository>();
builder.Services.AddScoped<ILocacaoRepository, LocacaoRepository>();
builder.Services.AddScoped<IMotoRepository, MotoRepository>();
    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Teste Mottu -- Gerenciamento de aluguel de motos",
        Version = "v1.0.0",
        Description = "Esta api tem como funcionalidade ser um BackEnd para que seja utilizado por outras aplicações web e etc.",
        Contact = new OpenApiContact
        {
            Name = "Rodrigo Batista Freire",
            Email = "rodrigofreirebatista@gmail.com",
            Url = new Uri("https://github.com/RodrigoBatis")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

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

app.Run();
