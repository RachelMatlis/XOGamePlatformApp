using System;
using System.Collections.Generic;
using DalInfraContracts;
using SQLInfraDAL;
using XOContracts;
using XODTO;
using XOServerContracts;

namespace GameServiceImpl
{
    public class GameService : IGameService
    {
        IXOBoard _board;
        IUserService _userService;
        IGamePlatformService _gamePlatformService;
        IGameValue _gameValue;
        IDAL _dal;
        string _endGameStatus;
       
        public GameService(IXOBoard board, IUserService userService, IGamePlatformService gamePlatformService, IDAL dal, IGameValue gameValue)
        {
            _board = board;
            _userService = userService;
            _gamePlatformService = gamePlatformService;
            _gameValue = gameValue;
            _dal = dal;
            _dal.ConnectionStr= "Server = RACHELMATLIS\\SQLEXPRESS; Database = XOAppDB; Trusted_Connection = True;";
        }

        public CreateGameResponseDTO CreateGame(GameDTO game)
        {
            var retval = new CreateGameResponseDTO();
            
            retval.GameToken = -1;
            retval.Success = false;

            if(_userService.isRegisterdUser(game.UserID))
            {
                int token = createToken();
                _gameValue.Board = _board;
                _gameValue.UserID = game.UserID;
                _gamePlatformService.GamePlatformDict.Add(token, _gameValue);
                retval.GameToken = token;
                retval.Success = true;
            }

            return retval;

        }

        public MakeMoveResponseDTO MakeMove(MoveDTO move)
        {
            var retval = new MakeMoveResponseDTO();
            retval.Success = false;
            string msg = null;
            if ( _gamePlatformService.GamePlatformDict.ContainsKey(move.GameToken))
            {
                if(_gamePlatformService.GamePlatformDict[move.GameToken].Board.getStatus() == Status.None)
                {
                    XOCellResponseDTO putResponse = new XOCellResponseDTO();
                    putResponse.PostmanMoveSucceed = (_gamePlatformService.GamePlatformDict[move.GameToken].Board.Put(move.XorO, move.Row, move.Col));
                    retval.Success = putResponse.PostmanMoveSucceed;
                    if (retval.Success)
                    {
                        if (_gamePlatformService.GamePlatformDict[move.GameToken].Board.getStatus() == Status.None)
                        {
                            msg = "Move completed successfully. Game In Progress";
                            gameInProgressResponse(move, msg, retval.Success, ref retval);
                        }
                        else
                        {
                            gameOverResponse(move, msg, retval.Success, ref retval);
                        }
  
                    }
                    else
                    {
                        msg = "Move not completed. Occupied Cell";
                        gameInProgressResponse(move, msg, retval.Success, ref retval);
                    }
                }
                else
                {
                    gameOverResponse(move, msg, retval.Success, ref retval);
                }

            }
            else
            {
                retval.Message = "Move not completed. Game Token Not Found";
                retval.Board = null;
            }


            return retval;

        }


        private int createToken()
        {
            Random rnd = new Random();
            int token = 0;
            do
            {
                token = rnd.Next(1000, 10000);
            }
            while (_gamePlatformService.GamePlatformDict.ContainsKey(token));

            return token;
            
        }

        private void gameOverResponse(MoveDTO move, string msg, bool isSuccess, ref MakeMoveResponseDTO responseDTO)
        {
            msg = gameOverMsg(move, isSuccess, ref responseDTO);
            updateRecordsTbl(move);
            makeResponse(move, msg, isSuccess, ref responseDTO);
            _gamePlatformService.GamePlatformDict.Remove(move.GameToken);
        }

        private void gameInProgressResponse(MoveDTO move, string msg, bool isSuccess, ref MakeMoveResponseDTO responseDTO)
        {
            makeResponse(move, msg, isSuccess, ref responseDTO);
        }

        private void makeResponse(MoveDTO move, string msg, bool isSuccess, ref MakeMoveResponseDTO responseDTO)
        {
            responseDTO.Message = msg;
            responseDTO.Board = _gamePlatformService.GamePlatformDict[move.GameToken].Board;
            responseDTO.Success = isSuccess;
        }

        private string gameOverMsg(MoveDTO move, bool isSuccess, ref MakeMoveResponseDTO responseDTO)
        {
            string msg = null;
            if (_gamePlatformService.GamePlatformDict[move.GameToken].Board.getStatus() == Status.Draw)
            {
                msg = isSuccess ? "Move completed successfully. Game Draw" : "Move not completed.Game Draw";
                _endGameStatus = "Draw";
            }
            else
            {
                msg = isSuccess ? "Move completed successfully. Player " : "Move not completed. Player ";
                msg += _gamePlatformService.GamePlatformDict[move.GameToken].Board.getStatus() + " Won";

                _endGameStatus = isSuccess ? "Won" : "Lost";
            }
           

            return msg;
        }

        private void updateRecordsTbl(MoveDTO move)
        {
            var paramUserID = _dal.CreateParameter("userID", _gamePlatformService.GamePlatformDict[move.GameToken].UserID);
            var paramGameToken = _dal.CreateParameter("gameToken", move.GameToken);
            var paramScore= _dal.CreateParameter("score", _endGameStatus);
            var datset = _dal.ExecuteQuery("AddRecord", paramUserID, paramGameToken, paramScore);
        }

    }
}
