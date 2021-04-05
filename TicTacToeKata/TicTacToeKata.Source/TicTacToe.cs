using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToeKata.Source
{
    public class TicTacToe
    {
        Dictionary<string, char> playerToLetter = new Dictionary<string, char>
        {
            {"FirstPlayer", 'X'},
            {"SecondPlayer", 'O'}
        };

        Dictionary<int, char> positionToLetter = new Dictionary<int, char>();

        public char GetCurrentPlayer(string player)
        {
            return playerToLetter[player];
        }

        public char MarkAtPosition(int position)
        {
            char letter;
            if (position == 2)
            {
                 letter = GetCurrentPlayer("SecondPlayer");
                positionToLetter.Add(position, letter);
                return positionToLetter[position];
            }
            letter = GetCurrentPlayer("FirstPlayer");
            positionToLetter.Add(position, letter);
            return positionToLetter[position];
        }
    }
}
