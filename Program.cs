using Domain.Interfaces;
using Infractructure.Plugins;

var builder = WebApplication.CreateBuilder(args);
// do a function to get server, database, user and password from environment variables

string connectionString = GetAppSettings.GetConnectionString();
builder.Services.AddScoped<IConnectionDB,MsSqlConnectionDB>(provider => new MsSqlConnectionDB(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); // Uncomment this line if you want to use HTTPS redirection in production environment 

app.UseAuthorization(); // Add this line if you want to use authorization in your application with JWT tokens

app.MapControllers();

// try the conection to database



app.Run();

public static class GetAppSettings
{
    public static string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .Build();
        string server =   config.GetSection("DataBases:ManufacturingPortal:Server").Value.ToString()??"";
        string database = config.GetSection("DataBases:ManufacturingPortal:Database").Value.ToString()??"";
        string user =   config.GetSection("DataBases:ManufacturingPortal:User").Value.ToString()??"";
        string password = config.GetSection("DataBases:ManufacturingPortal:Password").Value.ToString()??"";
        return $"Data Source={server};Initial Catalog={database}Persist Security Info=True;User Id={user};Password={password};Connection Timeout=120";
    }
}