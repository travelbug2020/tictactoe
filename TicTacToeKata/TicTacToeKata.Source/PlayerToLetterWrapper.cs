using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeKata.Source
{
    public class PlayerToLetterWrapper
    {
        readonly Dictionary<string, char> _playerToLetter = new Dictionary<string, char>
        {
            {"FirstPlayer", 'X'},
            {"SecondPlayer", 'O'}
        };

        private char _letter;
        public PlayerToLetterWrapper(string player)
        {
            _letter = _playerToLetter[player];
        }

        public char getLetter()
        {
            return _letter;
        }

        
    }
}
