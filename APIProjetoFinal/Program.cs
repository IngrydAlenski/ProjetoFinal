var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Run();


//Antes da linha app em cima dela
//CORSS

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name: "minhasOrigens",
            policy =>
            {
                policy.WithOrigins("http://localhost:5500");
            }
            
            );
    });
//Em baixo da linha do App e da MapControllers
//Para aplicar a aplicacao
app.UseCors("minhasOrigens");