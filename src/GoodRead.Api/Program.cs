var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddServiceServices(builder.Configuration);


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(configs =>
{
    configs.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Good Read API",
        Description = "Demo good read api",
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    configs.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//handle global exception
app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
