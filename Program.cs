using Microsoft.EntityFrameworkCore;
using PriorAuthPrototype.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Registers your database context (AppDbContext) into the DI container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPriorAuthorizationService, PriorAuthorizationService>();


var app = builder.Build();

//Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Converts it from HTTP to HTTPS - MAJOR HIPPA rule
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); //maps controller routes like /api/priorauthorization

app.Run();
