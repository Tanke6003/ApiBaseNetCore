

using ApiBaseNetCore.Infrastructure.Interfaces.plugins;


namespace ApiBaseNetCore.Infrastructure.Plugins
{
    public class Envs : IEnvs
    {
        public string GetEnv(string key)
        {

         IConfiguration config = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .Build();
        Encrypt64 e  = new Encrypt64();
        return e.Decrypt(config.GetSection(key)?.Value?.ToString()??"");
        }

        public string GetConnectionString(string key)
        {
          IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
          Encrypt64 e = new Encrypt64();
          string server = e.Decrypt(config.GetSection("DataBases:" + key + ":Server")?.Value?.ToString() ?? "");
          string database = e.Decrypt(config.GetSection("DataBases:" + key + ":Database")?.Value?.ToString() ?? "");
          string user = e.Decrypt(config.GetSection("DataBases:" + key + ":User")?.Value?.ToString() ?? "");
          string password = e.Decrypt(config.GetSection("DataBases:" + key + ":Password")?.Value?.ToString() ?? "");
          return $"Data Source={server};Initial Catalog={database};Persist Security Info=True;User Id={user};Password={password};TrustServerCertificate=true;Connection Timeout=120; Command Timeout=120";
        }
    }
}