using PruebaTecnicaAPI.Common;
using PruebaTecnicaAPI.Services;
using System.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region REGISTRO DE LAS DEPENDENCIAS

builder.Services.AddScoped<ICommon, Common>();
builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Services.AddScoped<ITicketsService, TicketsService>();
builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
	options.AddPolicy("TerminalCR", builder =>
	{
		builder.AllowAnyOrigin()
			   .AllowAnyMethod()
			   .AllowAnyHeader();
	});
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("TerminalCR");
app.UseAuthorization();
app.MapControllers();
app.Run();
