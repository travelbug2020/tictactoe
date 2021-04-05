using NUnit.Framework;
using TicTacToeKata.Source;

namespace TicTacToeKata.Test
{
    public class TicTacToeKataShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReturnX_AsFirstPlayer()
        {
            var ticTacToe = new TicTacToe();

            var result = ticTacToe.GetCurrentPlayer("FirstPlayer");
            
            Assert.AreEqual('X',result);
        } 

        [Test]
        public void ReturnO_AsSecondPlayer()
        {
            var ticTacToe = new TicTacToe();

            var result = ticTacToe.GetCurrentPlayer("SecondPlayer");

            Assert.AreEqual('O',result);
        }

        [Test]
        public void Player_MarkX_AtPosition1()
        {
            var ticTacToe = new TicTacToe();

            var result = ticTacToe.MarkAtPosition(1);

            Assert.AreEqual('X', result);
        }

        [Test]
        public void Player_MarkO_AtPosition2()
        {
            var ticTacToe = new TicTacToe();

            var result = ticTacToe.MarkAtPosition(2);

            Assert.AreEqual('O', result);
        }
    }
}