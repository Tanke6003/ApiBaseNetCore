using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Infrastructure.Interfaces.plugins;
using Infrastructure.Interfaces.Repository;
using Infractructure.Plugins;
using Infractructure.Repository;
using Infrastructure.Plugins;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Services;
using Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);
// do a function to get server, database, user and password from environment variables

// Add Plugins
builder.Services.AddScoped<IEnvs, Envs>(provider => new Envs());
builder.Services.AddScoped<IConnectionDB, MsSqlConnectionDB>(provider => new MsSqlConnectionDB(provider.GetRequiredService<IEnvs>().GetConnectionString("ManufacturingPortal")));
builder.Services.AddScoped<IEncrypt, Encrypt64>(provider => new Encrypt64());

// Add Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>(provider => new UserRepository(provider.GetRequiredService<IConnectionDB>()));

// Add Services
builder.Services.AddScoped<IUserService, UserService>(provider => new UserService(provider.GetRequiredService<IUserRepository>()));

// Configure CORS policy to allow requests from any origin, method, and header
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyOrigin()    // Allow any origin
            .AllowAnyMethod()    // Allow any method
            .AllowAnyHeader());  // Allow any header
});

// Create an instance of the IEnvs interface to retrieve the secret key
IEnvs envs = builder.Services.BuildServiceProvider().GetRequiredService<IEnvs>();

// Configure JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        // Get the secret key from environment variables
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(envs.GetEnv("SecretKey")))
    };
});

// Configure authorization
builder.Services.AddAuthorization();

// Register controllers
builder.Services.AddControllers();

// Register API endpoints
builder.Services.AddEndpointsApiExplorer();

// Configure Swagger for API documentation
builder.Services.AddSwaggerGen(c =>
{
    // Add API information
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiBaseNetCore", Version = "v1" });

    // Define the Bearer authorization scheme being used
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    // Add the Bearer authorization scheme to SwaggerUI
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

// Build the application
var app = builder.Build();

// Enable Swagger
app.UseSwagger();

// Configure SwaggerUI
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiBaseNetCore V1");
    c.DocExpansion(DocExpansion.None);
    c.DisplayRequestDuration();
});

// Apply CORS configuration
app.UseCors("CorsPolicy");

// Enable authentication
app.UseAuthentication();

// Enable authorization
app.UseAuthorization();

// Redirect from HTTP to HTTPS
//app.UseHttpsRedirection(); 

// Map the controllers
app.MapControllers();

// Run the application
app.Run();
