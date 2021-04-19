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
        private readonly WinningPositionsWrapper _winningPositionsWrapper = new WinningPositionsWrapper();

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
            foreach (var winningPosition in _winningPositionsWrapper.listOfWinningPositions)
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

    }
}  

