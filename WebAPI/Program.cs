using Persistence;
using Core;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Utilities.JWT;
using Microsoft.IdentityModel.Tokens;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.Utilities.Encryption;
using Infrastructure.SignalR;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
//    policy.WithOrigins()
//    .AllowAnyHeader().AllowAnyMethod().AllowCredentials()));



builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:4200", "http://localhost:4200").  //Ýstediðimiz kadar client ekleyebiliyoruz.
         AllowAnyHeader().
         AllowAnyMethod().
         AllowCredentials();
    });
});

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddPersistenceServices();
builder.Services.AddCoreServices(tokenOptions);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddHttpContextAccessor();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
//app.UseCors(
//    opt =>
//        opt.WithOrigins()
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowCredentials()
//);
app.UseCors("CorsPolicy");
app.MapHubs();

app.Run();
