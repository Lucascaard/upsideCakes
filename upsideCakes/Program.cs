using Microsoft.EntityFrameworkCore;
using upsideCakes.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UpsideCakesDbContext>();
// builder.Services.AddCors();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAnyOrigin",
	builder => builder
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAnyOrigin");
// app.UseCors(opcoes => opcoes.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
app.UseAuthorization();
app.MapControllers();

/*  DESCOMENTE PARA INSERIR DADOS FICTICIOS

 using (var scope = app.Services.CreateScope())
 {
     var dbContext = scope.ServiceProvider.GetRequiredService<UpsideCakesDbContext>();
     dbContext.Database.Migrate(); 
     dbContext.InserirDadosFicticios();
 }
*/
app.Run();
