using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using NUnit.Framework;
using TicTacToeKata.Source;

namespace TicTacToeKata.Test
{
    public class TicTacToeKataShould
    {
        private TicTacToe ticTacToe;
        [SetUp]
        public void Setup()
        {
            ticTacToe = new TicTacToe();
        }

        
        [Test]
        public void ReturnX_AsFirstPlayer()
        {
            var result = ticTacToe.GetCurrentPlayer();

            Assert.AreEqual('X', result);
        }

        [TestCase(new[]{1, 4, 2, 5, 3},"X wins!")]
        [TestCase(new[]{7, 4, 3, 5, 1,6},"O wins!")]
        [TestCase(new[]{7, 1, 8, 5, 3,6,9},"X wins!")]
        [TestCase(new[]{1, 2, 4, 8, 7,6,9},"X wins!")]
        [TestCase(new[]{2, 1, 5, 7, 8},"X wins!")]
        [TestCase(new[]{3, 1, 6, 7, 9},"X wins!")]
        [TestCase(new[]{1, 2, 5, 7, 9},"X wins!")]
        [TestCase(new[]{3, 1, 5, 9, 7},"X wins!")]
        public void PlayerWins_IfThreeInARow(int[] positions, string nameOfWinner)
        {
            foreach (var position in positions)
            {
                ticTacToe.MarkAtPosition(position);
            }
            var result = ticTacToe.GetWinner();

            Assert.AreEqual(nameOfWinner, result);
        }

        [Test]
        public void Game_ThrowError_IfPositionIsAlreadyPlayed()
        {
            var errorArray = new[] {1, 1};

            Assert.Throws<CanNotPlayPositionAlreadyPlayed>(() => {
                foreach (var position in errorArray)
                {
                    ticTacToe.MarkAtPosition(position);
                }
            });
        }

        [TestCase(new[] { 1, 2, 3, 5, 8,7,4,9,6 }, "DRAW")]
        public void PlayerTie_IfAllSquaresFilled_ButNoWinner(int[] positions, string nameOfWinner)
        {
            foreach (var position in positions)
            {
                ticTacToe.MarkAtPosition(position);
            }
            var result = ticTacToe.GetWinner();

            Assert.AreEqual(nameOfWinner, result);
        }

    }
}