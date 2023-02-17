using Api.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services
    .AddOpenTelemetry()
    .AddAuthenticationConfiguration(
        new ElvidConfig
        {
            ElvidAuthority = builder.Configuration["Elvid:Authority"],
            Scope = builder.Configuration["Elvid:Scope"]
        })
    //.AddAuthenticationConfiguration(
    //    new ElvidConfig
    //    {
    //        ElvidAuthority = builder.Configuration["Elvid:Authority"],
    //        Scope = builder.Configuration["Elvid:Scope"]
    //    })
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
