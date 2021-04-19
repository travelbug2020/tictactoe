using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TicTacToeKata.Source;
using static TicTacToeKata.Source.Player;
using static TicTacToeKata.Source.Position;

namespace TicTacToeKata.Test
{
    class TicTacToeOcShould
    {
        [Test]
        public void MakeX_FirstPlayer()
        {
            var ticTacToe = new TicTacToeOc();

            var player = ticTacToe.GetCurrentPlayer();

            Assert.AreEqual(X, player);
        }

        [Test]
        public void MakeO_SecondPlayer()
        {
            var ticTacToe = new TicTacToeOc();
            ticTacToe.MarkPosition(CenterLeft);

            var player = ticTacToe.GetCurrentPlayer();

            Assert.AreEqual(O,player);
        }

        [Test]
        public void MakeSure_PlayerAlternates()
        {
            var ticTacToe = new TicTacToeOc();
            ticTacToe.MarkPosition(CenterLeft);
            ticTacToe.MarkPosition(CenterMiddle);

            var player = ticTacToe.GetCurrentPlayer();

            Assert.AreEqual(X, player);
        }

        [Test]
        public void PlayerXWins_WhenTopRow_IsAllX()
        {
            var ticTacToe = new TicTacToeOc();
            ticTacToe.MarkPosition(TopLeft);
            ticTacToe.MarkPosition(CenterLeft);
            ticTacToe.MarkPosition(TopMiddle);
            ticTacToe.MarkPosition(CenterMiddle);
            ticTacToe.MarkPosition(TopRight);

            var player = ticTacToe.GetWinner();

            Assert.AreEqual(X,player);
        }
    }
}
