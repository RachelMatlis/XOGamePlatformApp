using System;
using System.Collections.Generic;
using System.Text;
using XOContracts;

namespace XOServerContracts
{
    public interface IGameValue
    {
        public IXOBoard Board { get; set; }
        public string UserID { get; set; }

    }
}
