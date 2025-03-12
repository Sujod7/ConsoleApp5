using Serilog;


var builder = WebApplication.CreateBuilder(args);

Log.Logger= new LoggerConfiguration() 
    .MinimumLevel.Debug()// ÈÚÏ ßÇ äÒáäÇ ÇáãßÊÈÉ Úã ÇÎÊÇÑ ÇáÈÑæÝÇíÏÑ Çáí ÑÍ ÊÔÊÛá Úáíåä
    .WriteTo.Console()
    .WriteTo.File("c:/log/log.txt", rollingInterval: RollingInterval.Day)//¡ æßá íæã ÈíÚãá ãáÝ ÌÏíÏ  íÚäí Çäå ÇÍÝÙáí ÇáÊáæßÇÊ ÈãáÝ ÌäÈå æÈÞÏÑ ÈÖíÝ ãÓÇÑ ãáÝ ¡ æÈÞÏÑ ÈÍØ ßá ÔÞÏ ÈÏí ÇÍÝÙ ÇáÊáæíßÇÊ ãËáÇ ãÑÉ ÈÇáíæã
    .CreateLogger(); // åíß ÇÓãäÇ ÚãáäÇ ßæäíÝßæÑíÔä áÍÊì äÓÌáä áÇÒã äßÊÈ ÊÍÊ

// Add services to the container.

builder.Services.AddControllers(options=> { options.ReturnHttpNotAcceptable = true; }).AddXmlDataContractSerializerFormatters().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog();//åÇÏ ÊÓÌíá ááãßÊÈÉ

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
//app.MapGet("/hi",() => "2hi");

app.Run();
