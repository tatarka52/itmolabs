using Microsoft.EntityFrameworkCore;
using RLab4.DB;
using RLab4.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DB"));
});


builder.Services.AddTransient<IRRepository, RRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();