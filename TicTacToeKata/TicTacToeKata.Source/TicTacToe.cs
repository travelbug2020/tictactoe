using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace TicTacToeKata.Source
{
    public class TicTacToe
    {
        Dictionary<string, char> playerToLetter = new Dictionary<string, char>
        {
            {"FirstPlayer", 'X'},
            {"SecondPlayer", 'O'}
        };

        private Dictionary<int, char> positionToLetter = new Dictionary<int, char>();
        
        bool firstPlayerTurn = true;
        bool secondPlayerTurn = false;

        public char GetCurrentPlayer()
        {
            string player = String.Empty;
            if (firstPlayerTurn)
            {
                firstPlayerTurn = false;
                secondPlayerTurn = true;
                player = "FirstPlayer";
            }
            else if (secondPlayerTurn)
            {
                secondPlayerTurn = false;
                firstPlayerTurn = true;
                player = "SecondPlayer";
            }

            return playerToLetter[player];
        }

        public Dictionary<int,char> MarkAtPosition(List<int> position)
        {
             
            foreach (var pos in position)
            {
                char letter;
                letter = GetCurrentPlayer();
                try
                {
                    positionToLetter.Add(pos, letter);
                    GetWinner(letter);
                }
                catch (ArgumentException)
                {
                    throw new CanNotPlayPositionAlreadyPlayed();
                }

            }

            return positionToLetter;

        }

        public string GetWinner(char letter)
        {
            if (positionToLetter.ContainsKey(1) && positionToLetter.ContainsKey(2) && positionToLetter.ContainsKey(3))
            {
                if (positionToLetter[1] == letter && positionToLetter[2] == letter && positionToLetter[3] == letter)
                {
                    return $"{letter} wins!";
                }
            }
            string winner = String.Empty;
            

            return null;
        }

        
    }
}
