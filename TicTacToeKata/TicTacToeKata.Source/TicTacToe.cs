using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace TicTacToeKata.Source
{
    public class TicTacToe
    {
        bool _firstPlayerTurn = true;
        bool _secondPlayerTurn = false;
        private string _player = "FirstPlayer";
        private readonly Dictionary<int, char> _positionToLetter = new Dictionary<int, char>();

        readonly List<int[]> _listOfWinningPositions = new List<int[]>
        {
            new [] {1,2,3},
            new [] {4,5,6},
            new [] {7,8,9},
            new [] {1,4,7},
            new [] {2,5,8},
            new [] {3,6,9},
            new [] {1,5,9},
            new [] {3,5,7}

        };
        public char GetCurrentPlayer()
        {
            PlayerToLetterWrapper playerToLetterWrapper = new PlayerToLetterWrapper(_player);
            return playerToLetterWrapper.getLetter();
        }

        public void MarkAtPosition(int position)
        {
            SwapPlayers();
            var noughtOrCross = GetCurrentPlayer();
            try
            {
                _positionToLetter.Add(position, noughtOrCross);
                
            }
            catch (ArgumentException)
            {
                throw new CanNotPlayPositionAlreadyPlayed();
            }
        }

        private void SwapPlayers()
        {
            if (_firstPlayerTurn)
            {
                _firstPlayerTurn = false;
                _secondPlayerTurn = true;
                _player = "FirstPlayer";
            }
            else if (_secondPlayerTurn)
            {
                _secondPlayerTurn = false;
                _firstPlayerTurn = true;
                _player = "SecondPlayer";
            }
        }

        public string GetWinner()
        {
            foreach (var winningPosition in _listOfWinningPositions)
            {
                var firstWinningPosition = winningPosition[0];
                var secondWinningPosition = winningPosition[1];
                var thirdWinningPosition = winningPosition[2];

                if (_positionToLetter.ContainsKey(firstWinningPosition) && _positionToLetter.ContainsKey(secondWinningPosition) && _positionToLetter.ContainsKey(thirdWinningPosition))
                {
                    if (_positionToLetter[firstWinningPosition] == 'X' && _positionToLetter[secondWinningPosition] == 'X' && _positionToLetter[thirdWinningPosition] == 'X')
                    {
                        return "X wins!";
                    }

                    if (_positionToLetter[firstWinningPosition] == 'O' && _positionToLetter[secondWinningPosition] == 'O' && _positionToLetter[thirdWinningPosition] == 'O')
                    {
                        return "O wins!";
                    }
                }
            }

            return "DRAW";
        }
        /**
        readonly Dictionary<string, char> _playerToLetter = new Dictionary<string, char>
        {
            {"FirstPlayer", 'X'},
            {"SecondPlayer", 'O'}
        };

        
        
        bool _firstPlayerTurn = true;
        bool _secondPlayerTurn = false;
        private string _player = "FirstPlayer";

        readonly List<int[]> _listOfWinningPositions = new List<int[]>
        {
            new [] {1,2,3},
            new [] {4,5,6},
            new [] {7,8,9},
            new [] {1,4,7},
            new [] {2,5,8},
            new [] {3,6,9},
            new [] {1,5,9},
            new [] {3,5,7}

        };

        public char GetCurrentPlayer()
        {
            return _playerToLetter[_player];
        }

    

        public string MarkAtPositions(int[] position)
        {
            if (position.Length > 9)
            {
                throw new ArgumentOutOfRangeException();
            }

            foreach (var pos in position)
            {
                if (MarkAtPosition(pos, out var winner)) 
                    return winner;
            }

            return "DRAW";

        }

        private bool MarkAtPosition(int pos, out string s)
        {
            var noughtOrCross = GetCurrentPlayer();
            try
            {
                _positionToLetter.Add(pos, noughtOrCross);
                if (GetWinner(noughtOrCross))
                {
                    {
                        s = $"{noughtOrCross} wins!";
                        return true;
                    }
                }

                SwapPlayers();
            }
            catch (ArgumentException)
            {
                throw new CanNotPlayPositionAlreadyPlayed();
            }

            return false;
        }

        private void SwapPlayers()
        {
            if (_firstPlayerTurn)
            {
                _firstPlayerTurn = false;
                _secondPlayerTurn = true;
                _player = "FirstPlayer";
            }
            if (_secondPlayerTurn)
            {
                _secondPlayerTurn = false;
                _firstPlayerTurn = true;
                _player = "SecondPlayer";
            }
        }

        
        **/
    }
}  

