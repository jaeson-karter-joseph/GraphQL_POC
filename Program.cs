using GraphQL.Data;
using GraphQL.Data.ContextConfigurations;
using GraphQL.Interfaces;
using GraphQL.Repositories;
using HotChocolate.Execution.Processing;
using Microsoft.EntityFrameworkCore;
using System.Data;
using HotChocolate.Data;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISuperheroRepository, SuperheroRepository>();
builder.Services.AddScoped<ISuperpowerRepository, SuperpowerRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddFiltering().AddSorting(); ;
// Add Application Db Context options
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("SqlServer")));


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

app.MapGraphQL("/graphql");

app.Run();
