using PokemonChallenge;
using PokemonChallenge.HttpServices;
using PokemonChallenge.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://::8080");

// add configuration file
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// register services
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("corsapp");

app.Run();


void ConfigureServices(IServiceCollection services, ConfigurationManager configurationManager)
{
    services.AddTransient<IApiConfiguration>(_ => configurationManager.GetSection("Application").Get<ApiConfiguration>());
    services.AddTransient<IPokiApiClient, PokiApiClientWrapper>();
    services.AddTransient<IPokemonService, PokemonService>();
    services.AddTransient<IPokeApiService, PokiApiClientService>();
    services.AddTransient<ITranslationService, ShakespeareTranslationService>();
    services.AddTransient<IHttpClient, HttpClientWrapper>();
}