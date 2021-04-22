using System.Collections.Generic;
using static TicTacToeKata.Source.Player;

namespace TicTacToeKata.Source
{
    public class TicTacToeOc
    {
        private Board scoreBoard = new Board();
        private Player currentPlayer = X;
        public Player GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public void MarkPosition(Position position)
        { //
          //scoreBoard.board.Add(GetCurrentPlayer(), position);
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