using eCommerce.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.AddDataBaseContexts();
builder.AddAuthenticationAndAuthorization();
builder.AddDIForServices();
builder.AddDIForRepositories();
builder.AddCors();
builder.AddEmailService();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.AddSwagger();

var app = builder.Build();

builder.Services.SeedCategoryData();
await builder.Services.SeedUserRoleData();
await builder.Services.SeedUserData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
