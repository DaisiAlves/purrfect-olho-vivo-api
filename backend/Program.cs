 
using purrfect_olho_vivo_api.Configuration; 

var builder = WebApplication.CreateBuilder(args);

// Adicionar DbContexts ao cont�iner
builder.Services.AddDbContexts(builder.Configuration);

// Adicionar servi�os ao cont�iner
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCustomCors();

var app = builder.Build();

app.UseCors("AllowLocalhost");

// Configurar o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplicar CORS antes de outros middlewares
app.UseCors("AllowLocalhost"); // Assegure-se de que o nome da pol�tica est� correto

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
