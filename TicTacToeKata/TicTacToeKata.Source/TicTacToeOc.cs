using System.Collections.Generic;
using static TicTacToeKata.Source.Player;

namespace TicTacToeKata.Source
{
    public class TicTacToeOc
    {
        private Board board = new Board();
        private Player currentPlayer = X;
        public Player GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public void MarkPosition(Position position)
        {
            
            SwapPlayers();
        }

        private void SwapPlayers()
        {
            if (currentPlayer == X)
            {
                currentPlayer = O;
                return;
            }

            currentPlayer = X;
        }

        public Player GetWinner()
        {
            return X;
        }
    }

    
}