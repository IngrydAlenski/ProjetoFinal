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

//Adicionando a autenticacao
builder.Services.AddAuthentication("Bearer") //informar o tipo de autenticacao
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,// Primeira validacao, verificar o Issue que foi passado do token
            ValidateAudience = true,//Valida a audiencia
            ValidateLifetime = true,//valida o tem de vida do token
            ValidateIssuerSigningKey = true,
            ValidIssuer = "APIProjetoFinal", //
            ValidAudience = "APIProjetoFinal",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai"))
        }; //Parametros de validacao de token, ou seja, como ele valida o token
    }); // Esse metodo so existe se baixar o pacote JwtBearer no projeto


builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors("minhasOrigens"); //Essa linha precisa sempre estar acima ou antes da linha app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization(); 

app.Run();
