using OasisSongbook.Business;
using OasisSongbook.Business.Context;
using OasisSongbook.Business.Services.Options;

var builder = WebApplication.CreateBuilder(args);

// Options
builder.Services.Configure<DocxTemplateServiceOptions>(builder.Configuration.GetSection(nameof(DocxTemplateServiceOptions)));
builder.Services.Configure<OasisSongbookNoSqlOptions>(builder.Configuration.GetSection(nameof(OasisSongbookNoSqlOptions)));

//builder.Services.AddOptions<DocxTemplateServiceOptions>().Bind(builder.Configuration);
//builder.Services.AddOptions<OasisSongbookNoSqlOptions>().Bind(builder.Configuration);

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
