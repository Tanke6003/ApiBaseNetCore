


using System.Data;
using Domain.Dtos;
using Infractructure.Interfaces;
using Infractructure.Interfaces.Repository;


namespace Infractructure.Repository{

    public class UserRepository: IUserRepository{

        private IConnectionDB _connectionDB;
        private IEncrypt _encrypt;

        public UserRepository(IConnectionDB connectionDB, IEncrypt encrypt){
            _connectionDB = connectionDB;
            _encrypt = encrypt;
        }

        public List<UserDto> GetUsers(){
            List<UserDto> users = new List<UserDto>();
            string query = "SELECT * FROM SC_Users";
            string exceptionMessage = "";
            DataTable dt = _connectionDB.GetDataTable(query, out exceptionMessage);
            if (exceptionMessage != ""){
                throw new Exception(exceptionMessage);
            }
            foreach (DataRow row in dt.Rows){
                UserDto user = new UserDto();
                user.Id = Convert.ToInt32(row["PKUser"]);
                user.NtUser = row["NTUser"].ToString();
                user.FullName = row["FullName"].ToString();
                user.Available = Convert.ToBoolean(row["Available"]);
                user.Email = row["Email"].ToString();
                user.LastUpdate = Convert.ToDateTime(row["LastUpdate"]);
                user.LastUpdateBy = Convert.ToInt32(row["FKLastUpdater"]);
                user.RoleId = Convert.ToInt32(row["FKRole"]);
                users.Add(user);
            }
            return users;
        }
    }
}