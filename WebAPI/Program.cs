using Persistence;
using Core;
using Application;
using Core.Utilities.JWT;
var builder = WebApplication.CreateBuilder(args);

//ILogEventEnricher[] enrichers = new ILogEventEnricher[]
//{
//    new CustomUserNameColumn()
//};

//// Serilog konfigürasyonu
//var columnOptions = new ColumnOptions();
//columnOptions.Store.Remove(StandardColumn.Properties);
//columnOptions.AdditionalColumns = new List<SqlColumn>
//{
//    new SqlColumn { ColumnName = "UserName", DataType = SqlDbType.NVarChar, DataLength = 50 },
//};


//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//    .Enrich.FromLogContext()
//    .Enrich.With(enrichers)
//    .Enrich.WithEnvironmentName()
//    .WriteTo.Console()
//    .WriteTo.File("logs/logs.txt")
//    .WriteTo.Seq("http://localhost:5341")
//    .WriteTo.MSSqlServer(
//        connectionString: builder.Configuration.GetConnectionString("SqlServer"),
//        sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true },
//        columnOptions: columnOptions
//    )
//    .CreateLogger();

//builder.Host.UseSerilog();
// Add services to the container.
TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddPersistenceServices();
builder.Services.AddCoreServices(tokenOptions);
builder.Services.AddApplicationServices();
builder.Services.AddHttpContextAccessor();


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
//app.UseMiddleware<UserNameLoggingMiddleware>(); // Middleware'i ekleyin
//app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
