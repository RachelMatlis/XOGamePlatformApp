using System;
using XOContracts;
using XOServerContracts;

namespace GamePlatformDictValue
{
    public class GameValue: IGameValue
    {
        public IXOBoard Board { get; set; }
        public string UserID { get; set; }

    }
}
