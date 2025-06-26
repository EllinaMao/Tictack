using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTackToes
{
    public class AIPlayer
    {
        private readonly GameLogic logic;
        private readonly string aiSymbol;
        private readonly string playerSymbol;

        public AIPlayer(GameLogic logic, bool isXAi)
        {
            this.logic = logic;
            aiSymbol = isXAi ? "X" : "O";
            playerSymbol = isXAi ? "O" : "X";
        }

        public (int row, int col)? GetBestMove()
        {
            // 1. Попробуй победить
            var winMove = FindWinningMove(aiSymbol);
            if (winMove != null) return winMove;

            // 2. Заблокируй противника
            var blockMove = FindWinningMove(playerSymbol);
            if (blockMove != null) return blockMove;

            // 3. Иначе - первый пустой
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (string.IsNullOrEmpty(logic.GameBoard[row, col]))
                        return (row, col);

            return null;
        }

        private (int row, int col)? FindWinningMove(string symbol)
        {
            for (int row = 0; row < 3; row++)
            {
                int count = 0, emptyCol = -1;
                for (int col = 0; col < 3; col++)
                {
                    if (logic.GameBoard[row, col] == symbol) count++;
                    else if (string.IsNullOrEmpty(logic.GameBoard[row, col])) emptyCol = col;
                }
                if (count == 2 && emptyCol != -1) return (row, emptyCol);
            }

            for (int col = 0; col < 3; col++)
            {
                int count = 0, emptyRow = -1;
                for (int row = 0; row < 3; row++)
                {
                    if (logic.GameBoard[row, col] == symbol) count++;
                    else if (string.IsNullOrEmpty(logic.GameBoard[row, col])) emptyRow = row;
                }
                if (count == 2 && emptyRow != -1) return (emptyRow, col);
            }

            // Диагонали
            int diagCount = 0, emptyDiag = -1;
            for (int i = 0; i < 3; i++)
            {
                if (logic.GameBoard[i, i] == symbol) diagCount++;
                else if (string.IsNullOrEmpty(logic.GameBoard[i, i])) emptyDiag = i;
            }
            if (diagCount == 2 && emptyDiag != -1) return (emptyDiag, emptyDiag);

            diagCount = 0; emptyDiag = -1;
            for (int i = 0; i < 3; i++)
            {
                if (logic.GameBoard[i, 2 - i] == symbol) diagCount++;
                else if (string.IsNullOrEmpty(logic.GameBoard[i, 2 - i])) emptyDiag = i;
            }
            if (diagCount == 2 && emptyDiag != -1) return (emptyDiag, 2 - emptyDiag);

            return null;
        }
    }
}
