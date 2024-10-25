using Orders.Infra;
using Orders.Application;
using Orders.Api.Filters;
using Orders.Infra.Migrations;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Exception Filter
builder.Services.AddMvc(op => op.Filters.Add(typeof(ExceptionsFilter)));

//Dependency Injection
builder.Services.AddInfraStructure(builder.Configuration);
builder.Services.AddApplication();

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

MigrateDatabase();

app.Run();

void MigrateDatabase()
{
    //if (builder.Configuration.IsUnitTestEnviroment())        return;

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

    DatabaseMigrartions.Migrate(connectionString, serviceScope.ServiceProvider);
}