using GoodRead.Domain;
using GoodRead.Domain.Context;
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDomainServices(builder.Configuration);
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

builder.Services.AddCors(options =>
{
    options.AddPolicy(name:MyAllowSpecificOrigins,
        policy  =>
        {
            policy.AllowAnyOrigin().WithHeaders().AllowAnyMethod();
        });
});

var app = builder.Build();
SeedData.AddDataInMemory(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

//handle global exception
app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
