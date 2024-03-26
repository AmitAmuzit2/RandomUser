using RandomUserAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
//Configure the Health Checks service

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//add httpClient service
//builder.Services.AddHttpClient();
builder.Services.AddHttpClient<UserService>();
builder.Services.AddSingleton<AuthService>(new AuthService("testuser", "testpassword"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Map the Health Check endpoint 
app.MapHealthChecks("/health");
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();


app.Run();
