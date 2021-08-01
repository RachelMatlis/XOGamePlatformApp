using System;
using System.Collections.Generic;
using System.Text;
using XOContracts;

namespace XOServerContracts
{
    public interface IGamePlatformService
    {
        public Dictionary<int, IGameValue> GamePlatformDict{ get;}
    }
}
