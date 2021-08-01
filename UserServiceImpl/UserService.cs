using System;
using DalInfraContracts;
using SQLInfraDAL;
using XODTO;
using XOServerContracts;

namespace UserServiceImpl
{
    public class UserService: IUserService
    {
        IDAL _dal;

        public UserService(IDAL dal)
        {
            _dal = dal;
            _dal.ConnectionStr = "Server = RACHELMATLIS\\SQLEXPRESS; Database = XOAppDB; Trusted_Connection = True;";
        }
        public RegisterUserResponseDTO RegisterUser(UserDTO user)
        {
            var retval = new RegisterUserResponseDTO();
            retval.Success = false;

            var paramUserID = _dal.CreateParameter("userID", user.UserID);
            var paramUserName = _dal.CreateParameter("userName", user.UserName);

            if (isRegisterdUser(user.UserID) == false)
            {
                _dal.ExecuteNonQuery("AddUser", paramUserID, paramUserName);
                retval.Success = true;
            }

            return retval;

        }

        public bool isRegisterdUser(string userID)
        {
            var retval = true;
            var paramUserID = _dal.CreateParameter("userID", userID);
            var datset = _dal.ExecuteQuery("GetUser", paramUserID);

            if (datset.Tables[0].Rows.Count == 0)
                retval = false;

            return retval;
        }
    }
}
