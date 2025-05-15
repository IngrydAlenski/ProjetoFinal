using APIProjetoFinal.Context;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Dbg5Context>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

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

var app = builder.Build();

app.UseCors("minhasOrigens"); //Essa linha precisa sempre estar acima ou antes da linha app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
