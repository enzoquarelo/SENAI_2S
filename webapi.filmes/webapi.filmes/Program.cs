using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adiciona o servico de controller
builder.Services.AddControllers();





builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes - SENAI",
        Description = "API para gerenciamento de filmes, projeto feito durante a Sprint2 Back-End API.",
        Contact = new OpenApiContact
        {
            Name = "GitHub do Projeto - Enzo Quarelo",
            Url = new Uri("https://github.com/enzoquarelo/SENAI_2S_bd")
        }
    });

    //Configura o swagger para usar o arquivo XML gerado (comentário)
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//comeca a configuracaos do swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//Finaliza a configuração do Swagerr

//adiciona mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();