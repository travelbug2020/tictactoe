using System;
using System.Collections.Generic;
using NUnit.Framework;
using TicTacToeKata.Source;

namespace TicTacToeKata.Test
{
    public class TicTacToeKataShould
    {
// private TicTacToe ticTacToe;
        [SetUp]
        public void Setup()
        {
            //ticTacToe = new TicTacToe();
        }

        [Test]
        public void ReturnX_AsFirstPlayer()
        {
            var ticTacToe = new TicTacToe();

            var result = ticTacToe.GetCurrentPlayer();

            Assert.AreEqual('X', result);
        }

        [Test]
        public void Player_MarkX_AtPosition1()
        {
            var ticTacToe = new TicTacToe();

            var result = ticTacToe.MarkAtPosition(new List<int>() {1});

            Assert.AreEqual(new Dictionary<int, char> {{1, 'X'}}, result);
        }

        [Test]
        public void Player_MarkLetters_AtPosition()
        {
            var ticTacToe = new TicTacToe();

            var result = ticTacToe.MarkAtPosition(new List<int> { 1, 2 });

            CollectionAssert.AreEqual(new Dictionary<int, char> { { 1, 'X' }, { 2, 'O' } }, result);
        }

        [Test]
        public void Game_ThrowError_IfPositionIsAlreadyPlayed()
        {
            var ticTacToe = new TicTacToe();

            Assert.Throws<CanNotPlayPositionAlreadyPlayed>(() => { ticTacToe.MarkAtPosition(new List<int> {1, 1}); });
        }

        [Test]
        public void PlayerWins_IfThreeInARow()
        {
            var ticTacToe = new TicTacToe();

            var result = ticTacToe.MarkAtPosition(new List<int>{1, 4, 2, 5, 3});

            Assert.AreEqual("X wins!", result);
        }
        

    }
}