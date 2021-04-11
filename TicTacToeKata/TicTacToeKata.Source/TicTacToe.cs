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
            string player = String.Empty;
            if (_firstPlayerTurn)
            {
                _firstPlayerTurn = false;
                _secondPlayerTurn = true;
                player = "FirstPlayer";
            }
            else if (_secondPlayerTurn)
            {
                _secondPlayerTurn = false;
                _firstPlayerTurn = true;
                player = "SecondPlayer";
            }

            return _playerToLetter[player];
        }


        public string MarkAtPosition(int[] position)
        {
            if (position.Length > 9)
            {
                throw new ArgumentOutOfRangeException();
            }
             
            foreach (var pos in position)
            {
                var letter = GetCurrentPlayer();
                try
                {
                    _positionToLetter.Add(pos, letter);
                    var winner = CheckIfThereIsAWinner(letter);
                    if (winner)
                    {
                        return $"{letter} wins!";
                    }
                }
                catch (ArgumentException)
                {
                    throw new CanNotPlayPositionAlreadyPlayed();
                }

            }

            return "DRAW";

        }

        public bool CheckIfThereIsAWinner(char letter)
        {

            foreach (var positionArray in _listOfWinningPositions)
            {
                var firstKeyToCheck = positionArray[0];
                var secondKeyToCheck = positionArray[1];
                var thirdKeyToCheck = positionArray[2];

                if (_positionToLetter.ContainsKey(firstKeyToCheck) && _positionToLetter.ContainsKey(secondKeyToCheck) && _positionToLetter.ContainsKey(thirdKeyToCheck))
                {
                    if (_positionToLetter[firstKeyToCheck] == letter && _positionToLetter[secondKeyToCheck] == letter && _positionToLetter[thirdKeyToCheck] == letter)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
