using System;
using System.Collections.Generic;
using System.Text;
using XODTO;

namespace XOServerContracts
{
    public interface IUserService
    {
        public RegisterUserResponseDTO RegisterUser(UserDTO user);
        public bool isRegisterdUser(string userID);
    }
}
