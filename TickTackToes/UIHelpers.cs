﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace TickTackToes
{
    public static class UIHelpers
    {
        public static void ShowPlayerTurn(bool isX)
        {
            MessageBox.Show($"Ход игрока {(isX ? "X" : "O")}", "Ход", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWin(bool isX)
        {
            MessageBox.Show($"{(isX ? "X" : "O")} победил!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowDraw()
        {
            MessageBox.Show("Ничья!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
