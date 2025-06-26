using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;

namespace TickTackToes
{
    public partial class TickTackToe : Form
    {
        private bool isXTurn; // Track whose turn it is
        private int movesCount = 0;
        private string[,] gameBoard;
        private bool isSoloGame;
        private bool isGameWon = false;
        public TickTackToe(bool GameChoice)
        {
            int randomNumber = new Random().Next(0, 2); // верхняя не включительно
            isXTurn = Convert.ToBoolean(randomNumber);

            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += TickTackToe_KeyDown;
            this.FormClosing += ExitButton_Click;

            FillArray();

            PlayerMessage();
            isSoloGame = GameChoice;//true - solo game, false - multiplayer


        }
        private void TickTackToe_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void PlayerMessage()
        {
            if (isXTurn)
            {
                MessageBox.Show("Ход игрока X");
            }
            else
            {
                MessageBox.Show("Ход игрока O");
            }
        }
        private void ResetGame()
        {
            foreach (Control control in tableLayoutPanel2.Controls)
            {
                if (control is Button button)
                {
                    button.Text = string.Empty;
                    button.Enabled = true;
                }
            }
            isXTurn = new Random().Next(0, 2) == 0; // Случайный выбор, кто начинает
            movesCount = 0;
            FillArray();
        }
        private void FillArray()
        {
            gameBoard = new string[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    gameBoard[row, col] = string.Empty;
                }
            }
        }
        private void TickTackToe_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null || !string.IsNullOrEmpty(btn.Text))
            {
                return;
            }

            btn.Text = isXTurn ? "X" : "O";
            btn.Enabled = false;
            movesCount++;
            gameBoard[tableLayoutPanel2.GetRow(btn), tableLayoutPanel2.GetColumn(btn)] = btn.Text;

            GameLogic();
            isXTurn = !isXTurn;
        }
        
        private void AIMove(int row, int emptyCol, char symbol)
        {
            
        }
        private bool TryCompleteRow(string simbol)
        {
            int count, emptyCol;
            for (int row = 0; row < 3; row++)
            {
                count = 0; emptyCol = -1;
                for (int col = 0; col<3; col++)
                {
                    if (gameBoard[row, col] == simbol)
                    {
                        count++;
                    }
                    else if (string.IsNullOrEmpty(gameBoard[row, col]))
                    { 
                        emptyCol = col;
                    }
                }
            }
            return false;

        }
        
        private void ExitButton_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool CheckWin() {
            for (int j = 0; j < 3; j++)
            {
                if (!string.IsNullOrEmpty(this.gameBoard[j, 0]) &&
                    this.gameBoard[j, 0] == this.gameBoard[j, 1] && this.gameBoard[j, 1] == this.gameBoard[j, 2])
                {
                    return true;
                }
                if (!string.IsNullOrEmpty(this.gameBoard[0, j]) &&
                    this.gameBoard[0, j] == this.gameBoard[1, j] && this.gameBoard[1, j] == this.gameBoard[2, j])
                { return true; }
            }
            if (!string.IsNullOrEmpty(gameBoard[0, 0]) &&
             gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2])
            { return true; }
            if (!string.IsNullOrEmpty(gameBoard[0, 2]) &&
                gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0])
            { return true; }

            return false;
        }
        private bool CheckDraw()
        {
            return movesCount == 9 && !isGameWon;
        }
        private bool GameLogic()
        {
            isGameWon=CheckWin();
            if (isGameWon)
            {
                MessageBox.Show($"{(isXTurn ? "X" : "O")} победил!");
                ResetGame();
                return true;
            }
            if (CheckDraw())
            {
                MessageBox.Show("Ничья!");
                ResetGame();
                return true;
            }
            return false;
        }




    }
}
