using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text;
using APIProjetoFinal.Context;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Repositories;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

//implementando configuracao do pacote NewtonSoft, serve para substituir o jsonignore da modelo para lidar com os loops entre tabelas
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

builder.Services.AddDbContext<Dbg5Context>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<INotaRepository, NotaRepository>();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name: "minhasOrigens",
            policy =>
            {
                //TODO: alterar link para o front end
                policy.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            }
         );
    });
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "APIProjetoFinal",
            ValidAudience = "APIProjetoFinal",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ee4f0db1a86eeddfe9d7e9b68be0ff11860114bc14cf867570e1e3a7fa1d93ad"))
        };
    });
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API-ProjetoFinal", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

//builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
var app = builder.Build();
app.UseCors("minhasOrigens"); 
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
