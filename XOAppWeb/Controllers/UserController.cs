using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XODTO;
using XOServerContracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XOAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase // sign-up a user
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/<UserController>
        [HttpPost]
        public RegisterUserResponseDTO Post([FromBody] UserDTO user)
        {
            var retval = _userService.RegisterUser(user);
            return retval;
        }
    }


}
