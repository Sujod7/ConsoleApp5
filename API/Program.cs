using Serilog;


var builder = WebApplication.CreateBuilder(args);

Log.Logger= new LoggerConfiguration() 
    .MinimumLevel.Debug()// ��� �� ����� ������� �� ����� ���������� ��� �� ����� �����
    .WriteTo.Console()
    .WriteTo.File("c:/log/log.txt", rollingInterval: RollingInterval.Day)//� ��� ��� ����� ��� ����  ���� ��� ������ �������� ���� ���� ����� ���� ���� ��� � ����� ��� �� ��� ��� ���� ��������� ���� ��� ������
    .CreateLogger(); // ��� ����� ����� ����������� ���� ����� ���� ���� ���

// Add services to the container.

builder.Services.AddControllers(options=> { options.ReturnHttpNotAcceptable = true; }).AddXmlDataContractSerializerFormatters().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog();//��� ����� �������

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
