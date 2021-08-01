using System;
using System.Collections.Generic;
using XOContracts;
using XOServerContracts;

namespace GamePlatformServiceImpl
{
    public class GamePlatformService: IGamePlatformService
    {
        private Dictionary<int, IGameValue> _gamePlatformDict = new Dictionary<int, IGameValue>();
        //private Dictionary<int, IXOBoard> _gamePlatformDict = new Dictionary<int, IXOBoard>();

        public Dictionary<int, IGameValue> GamePlatformDict 
        { 
            get 
            {
                return _gamePlatformDict;
            } 
        }
    }
}
