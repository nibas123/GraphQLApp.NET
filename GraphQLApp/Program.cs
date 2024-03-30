using GraphQLApp.GraphQL.MutationTypes;
using GraphQLApp.GraphQL.QueryTypes;
using GraphQLApp.Models;
using GraphQLApp.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IStudentRepositry, StudentRepositry>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddGraphQLServer()
                .AddQueryType<StudentQueryTypes>()
                .AddMutationType<StudentMutation>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.MapGraphQL();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
