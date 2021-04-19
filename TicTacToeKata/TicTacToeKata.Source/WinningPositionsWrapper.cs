using System.Collections.Generic;

namespace TicTacToeKata.Source
{
    public class WinningPositionsWrapper
    {
        public readonly List<int[]> listOfWinningPositions = new List<int[]>
        {
            new [] {1,2,3},
            new [] {4,5,6},
            new [] {7,8,9},
            new [] {1,4,7},
            new [] {2,5,8},
            new [] {3,6,9},
            new [] {1,5,9},
            new [] {3,5,7}

        };
    }
}