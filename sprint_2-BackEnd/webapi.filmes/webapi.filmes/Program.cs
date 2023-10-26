using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adiciona o servico de controller
builder.Services.AddControllers();

//adiciona servico jwt bearer (forma de autenticacao)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         //valida quem está solicitando
         ValidateIssuer = true,

         //valida quem está recebendo
         ValidateAudience = true,

         //define se o tempo de expiracao sera validado 
         ValidateLifetime = true,

         //froma de criptografia e valida a chave de autenticacao
         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

         //valida o tempo de expiracao do token
         ClockSkew = TimeSpan.FromMinutes(5),

         //nome do issuer (de onde está vindo)
         ValidIssuer = "webapi.filmes",

         //nome do audience (para onde está indo)
         ValidAudience = "webapi.filmes"
     };
 });



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

    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

//adiciona autenticação
app.UseAuthentication();

//adiciona autorização
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();