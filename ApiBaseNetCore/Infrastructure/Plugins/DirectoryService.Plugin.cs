using System.Reflection.PortableExecutable;
using ApiBaseNetCore.Domain.Dtos;
using ApiBaseNetCore.Domain.Interfaces.Plugins;
using ApiBaseNetCore.Infrastructure.Interfaces.plugins;
using System.DirectoryServices;
using DirectoryEntry = System.DirectoryServices.DirectoryEntry;

namespace ApiBaseNetCore.Infrastructure.Plugins{

    public class DirectoryService:IDirectoryService{
    
        public bool Authenticate(string username, string password){
              try{
            IEnvs envs = new Envs();
            DirectoryEntry de = new DirectoryEntry(envs.GetEnv("LDAP"), username, password);
            DirectorySearcher ds = new DirectorySearcher(de);
            ds.FindOne();
                return true;
            }catch{
                return false;
            }


        }

        public UserDirectoryServiceDto GetUserByNtUser(string ntUser){
            UserDirectoryServiceDto user = new UserDirectoryServiceDto();
            try{
                IEnvs envs = new Envs();
                DirectoryEntry de = new DirectoryEntry(envs.GetEnv("LDAP"));
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.Filter = "(&(objectClass=user)(samaccountname=" + ntUser + "))";
                SearchResult result = ds.FindOne();
                if (result != null){
                    user.EmployeeNumber = int.Parse(result.Properties["employeenumber"][0].ToString());
                    user.Email = result.Properties["mail"][0].ToString();
                    user.FullName = result.Properties["displayName"][0].ToString();
                    user.NtUser = result.Properties["samaccountname"][0].ToString();
                }
            }catch{ 
                user = null;
            }
            return user;
        }

        public UserDirectoryServiceDto GetUserByEmployeeNumber(int employeeNumber){
            UserDirectoryServiceDto user = new UserDirectoryServiceDto();
            try{
                IEnvs envs = new Envs();
                DirectoryEntry de = new DirectoryEntry(envs.GetEnv("LDAP"));
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.Filter = "(&(objectClass=user)(employeenumber=" + employeeNumber + "))";
                SearchResult result = ds.FindOne();
                if (result != null){
                    user.EmployeeNumber = int.Parse(result.Properties["employeenumber"][0].ToString());
                    user.Email = result.Properties["mail"][0].ToString();
                    user.FullName = result.Properties["displayName"][0].ToString();
                    user.NtUser = result.Properties["samaccountname"][0].ToString();
                }
            }catch{
                user = null;
            }
            return user;
        }

        public UserDirectoryServiceDto GetUserByEmail(string email){
            UserDirectoryServiceDto user = new UserDirectoryServiceDto();
            try{
                IEnvs envs = new Envs();
                DirectoryEntry de = new DirectoryEntry(envs.GetEnv("LDAP"));
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.Filter = "(&(objectClass=user)(mail=" + email + "))";
                SearchResult result = ds.FindOne();
                if (result != null){
                    user.EmployeeNumber = int.Parse(result.Properties["employeenumber"][0].ToString());
                    user.Email = result.Properties["mail"][0].ToString();
                    user.FullName = result.Properties["displayName"][0].ToString();
                    user.NtUser = result.Properties["samaccountname"][0].ToString();
                }
            }catch{
                user = null;
            }
            return user;
        }
        
    }
}