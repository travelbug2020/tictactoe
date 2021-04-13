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
        readonly Dictionary<string, char> _playerToLetter = new Dictionary<string, char>
        {
            {"FirstPlayer", 'X'},
            {"SecondPlayer", 'O'}
        };

        private readonly Dictionary<int, char> _positionToLetter = new Dictionary<int, char>();
        
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
                if (ThereIsAWinner(noughtOrCross))
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
            else if (_secondPlayerTurn)
            {
                _secondPlayerTurn = false;
                _firstPlayerTurn = true;
                _player = "SecondPlayer";
            }
        }

        public bool ThereIsAWinner(char noughtOrCross)
        {

            foreach (var positionArray in _listOfWinningPositions)
            {
                var firstKeyToCheck = positionArray[0];
                var secondKeyToCheck = positionArray[1];
                var thirdKeyToCheck = positionArray[2];

                if (_positionToLetter.ContainsKey(firstKeyToCheck) && _positionToLetter.ContainsKey(secondKeyToCheck) && _positionToLetter.ContainsKey(thirdKeyToCheck))
                {
                    if (_positionToLetter[firstKeyToCheck] == noughtOrCross && _positionToLetter[secondKeyToCheck] == noughtOrCross && _positionToLetter[thirdKeyToCheck] == noughtOrCross)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
