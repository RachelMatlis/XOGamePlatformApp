using System;
using SQLInfraDAL;

namespace RegisterdUserImpl
{
    public class RegisterdUser
    {
        public bool isRegisterdUser(string userID, DAL dal)
        {
            var retval = true;
            var paramUserID = dal.CreateParameter("userID", userID);
            var datset = dal.ExecuteQuery("GetUser", paramUserID);

            if (datset.Tables[0].Rows.Count == 0)
                retval = false;

            return retval;
        }
    }
}
