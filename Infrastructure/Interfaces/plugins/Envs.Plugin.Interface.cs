
namespace Infractructure.Interfaces.plugins
{
    public interface IEnvs
    {
        string GetEnv(string key);
        string GetConnectionString(string key);
        
    }
}