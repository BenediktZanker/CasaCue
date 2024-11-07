using CasaCue.Data.Contract;
using CasaCue.Data.Implementation;
using CasaCue.Data.Models;
using CasaCue.Repository.Contract;
using CasaCue.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IDataContext, EfDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuestConnection"));
});

builder.Services.AddScoped<IDataRepository<Guest>, DataRepository<Guest>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.Run();


