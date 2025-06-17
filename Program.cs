using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Agregar la política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("VercelFrontend",
        policy =>
        {
            policy.WithOrigins("https://laboratorio3-cliente.vercel.app") // Dominio principal
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.Configure<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});


builder.Services.AddDbContext<Laboratorio3ApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Laboratorio3ApiContext") ?? throw new InvalidOperationException("Connection string 'Laboratorio3ApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("VercelFrontend");
app.UseAuthorization();
app.UseDeveloperExceptionPage(); // si estás en modo desarrollo
app.MapControllers();

app.Run();
