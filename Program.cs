using Amazon.SimpleNotificationService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());

// Add services to the container
builder.Services.AddDbContext<MotoRentalContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories and services
builder.Services.AddScoped<IMotoRepository, MotoRepository>();
builder.Services.AddScoped<IEntregadorRepository, EntregadorRepository>();
builder.Services.AddScoped<ILocacaoRepository, LocacaoRepository>();
builder.Services.AddScoped<MotoService>();
builder.Services.AddScoped<EntregadorService>();
builder.Services.AddScoped<LocacaoService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// SNS (Amazon Simple Notification Service)
builder.Services.AddAWSService<IAmazonSimpleNotificationService>();

// AddControllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Pipeline config
// if (app.Environment.IsDevelopment())
// {
   app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoRentalApp v1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
// }


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Apply migrations and create db
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MotoRentalContext>();
    context.Database.Migrate();  // Applying pending migrations
}

app.Run();
