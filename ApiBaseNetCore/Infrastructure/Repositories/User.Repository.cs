using System.Data;
using ApiBaseNetCore.Domain.Dtos;
using ApiBaseNetCore.Domain.Interfaces.Repository;
using ApiBaseNetCore.Infrastructure.Interfaces;



namespace ApiBaseNetCore.Infrastructure.Repository{

    public class UserRepository: IUserRepository{

        private IConnectionDB _connectionDB;
    

        public UserRepository(IConnectionDB connectionDB){
            _connectionDB = connectionDB;
        }

        public List<UserDto> GetUsers(out string exceptionMessage){
            List<UserDto> users = new List<UserDto>();
            try{
                string query = "SELECT * FROM SC_Users";
           
            DataTable dt = _connectionDB.GetDataTable(query, out exceptionMessage);
            if (exceptionMessage != ""){
                throw new Exception(exceptionMessage);
            }
            foreach (DataRow row in dt.Rows){
                UserDto user = new UserDto();
                user.Id = Convert.ToInt32(row["PKUser"]);
                user.NtUser = row["NTUser"].ToString()??"";
                user.FullName = row["FullName"].ToString()??"";
                user.Available = Convert.ToBoolean(row["Available"]);
                user.Email = row["Email"].ToString()??"";
                user.LastUpdate = Convert.ToDateTime(row["LastUpdate"]);
                user.LastUpdateBy = Convert.ToInt32(row["FKLastUpdater"]);
                user.RoleId = Convert.ToInt32(row["FKRole"]);
                users.Add(user);
            }
            }
            catch (Exception ex){
                exceptionMessage = ex.Message;
            }
            return users;
        }
        public UserDto GetUserById(int id, out string exceptionMessage){
            UserDto user = new UserDto();
            try{
                string query = $"SELECT * FROM SC_Users WHERE PKUser = {id}";
                DataTable dt = _connectionDB.GetDataTable(query, out exceptionMessage);
                if (exceptionMessage != ""){
                    throw new Exception(exceptionMessage);
                }
                DataRow row = dt.Rows[0];
                user.Id = Convert.ToInt32(row["PKUser"]);
                user.NtUser = row["NTUser"].ToString()??"";
                user.FullName = row["FullName"].ToString()??"";
                user.Available = Convert.ToBoolean(row["Available"]);
                user.Email = row["Email"].ToString()??"";
                user.LastUpdate = Convert.ToDateTime(row["LastUpdate"]);
                user.LastUpdateBy = Convert.ToInt32(row["FKLastUpdater"]);
                user.RoleId = Convert.ToInt32(row["FKRole"]);
            }
            catch (Exception ex){
                exceptionMessage = ex.Message;
            }
            return user;
        }
    }
}