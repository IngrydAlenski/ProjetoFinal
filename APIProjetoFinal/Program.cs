using System.Text;
using APIProjetoFinal.Context;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

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
                policy.WithOrigins("http://localhost:5000");
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

builder.Services.AddAuthentication();
var app = builder.Build();
app.UseCors("minhasOrigens"); 
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
