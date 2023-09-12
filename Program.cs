using httpclient_create.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddHttpClient("rapidapi", client =>
{
    client.BaseAddress = new Uri("https://google-translate1.p.rapidapi.com");
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "35f1d1aeeemsh3ad9c6de0f0b1aep176963jsn21587b71b364");
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "google-translate1.p.rapidapi.com");
});

builder.Services.AddHttpClient<LanguageClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
