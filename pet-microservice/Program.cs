var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        //This makes that the serialization of an enum to return the string value and not the integer value
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Development CORS policy (Angular on localhost)
const string devCorsPolicy = "DevCors";
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(devCorsPolicy, policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
    });
}

// Production CORS policy (replace with your real frontend domain)
const string prodCorsPolicy = "ProdCors";
if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(prodCorsPolicy, policy =>
        {
            policy.WithOrigins("http://petstore-frontend-adoreal.s3-website-sa-east-1.amazonaws.com") // <-- replace with your actual production frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();

    // Use development CORS policy
    app.UseCors(devCorsPolicy);
}
else
{
    // EB sets PORT env variable; default to 5000 if not set
    var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
    app.Urls.Add($"http://*:{port}");
    // Use production CORS policy
    app.UseCors(prodCorsPolicy);
}



app.UseAuthorization();

app.MapControllers();

app.Run();
