using Microsoft.EntityFrameworkCore;
using API.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Pode inserir aqui para o PostgreSQL, após instalar as dependências.
builder.Services.AddDbContext<DatabaseContext>(db => db.UseInMemoryDatabase("dbContractsManagement"));

// Cria-se instância sem precisar declara o "new", em toda a aplicação.
builder.Services.AddScoped<DatabaseContext, DatabaseContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
