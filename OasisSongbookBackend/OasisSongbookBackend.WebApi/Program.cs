using OasisSongbook.Business;
using OasisSongbook.Business.Context;
using OasisSongbook.Business.Services.Options;

var builder = WebApplication.CreateBuilder(args);

// Options
builder.Configuration.Bind(new DocxTemplateServiceOptions());
builder.Configuration.Bind(new OasisSongbookNoSqlOptions());

// Add services to the container.
builder.Services.AddBusiness();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
