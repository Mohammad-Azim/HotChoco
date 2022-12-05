using HotChoco.GprahQL.Jwt.Auth.GraphQLModel.ObjectType;
using HotChoco.GprahQL.Jwt.Auth.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGraphQLServer()
.AddQueryType<QueryObjectType>()
.AddMutationType<MutationObjectType>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));


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
app.MapGraphQL();


app.Run();
