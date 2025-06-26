using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

namespace TickTackToes
{
    public partial class TickTackToe : Form
    {
        private bool isXTurn;
        private GameLogic logic;
        private bool isSoloGame;
        private bool isGameWon = false;
        private AIPlayer? aiPlayer;

        public TickTackToe(bool GameChoice)
        {
            int randomNumber = new Random().Next(0, 2);
            isXTurn = Convert.ToBoolean(randomNumber);
            isSoloGame = GameChoice;

            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += TickTackToe_KeyDown;
            this.FormClosing += ExitButton_Click;

            logic = new GameLogic();
            if (isSoloGame)
            {
                aiPlayer = new AIPlayer(logic, !isXTurn);
            }

            UIHelpers.ShowPlayerTurn(isXTurn);
        }

        private void TickTackToe_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void ExitButton_Click(object? sender, EventArgs e)
        {
            Application.Exit();
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
            isXTurn = new Random().Next(0, 2) == 0;
            logic.Reset();
            isGameWon = false;

            if (isSoloGame)
            {
                aiPlayer = new AIPlayer(logic, !isXTurn);
            }

            UIHelpers.ShowPlayerTurn(isXTurn);
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null || !string.IsNullOrEmpty(btn.Text)) return;

            btn.Text = isXTurn ? "X" : "O";
            btn.Enabled = false;

            int row = tableLayoutPanel2.GetRow(btn);
            int col = tableLayoutPanel2.GetColumn(btn);

            logic.MakeMove(row, col, btn.Text);
            GameLogic();

            isXTurn = !isXTurn;

            if (isSoloGame && !isGameWon && !logic.CheckDraw())
            {
                var aiMove = aiPlayer?.GetBestMove();
                if (aiMove is not null)
                {
                    var (aiRow, aiCol) = aiMove.Value;
                    foreach (Control control in tableLayoutPanel2.Controls)
                    {
                        if (control is Button aiBtn &&
                            tableLayoutPanel2.GetRow(aiBtn) == aiRow &&
                            tableLayoutPanel2.GetColumn(aiBtn) == aiCol)
                        {
                            aiBtn.PerformClick();
                            break;
                        }
                    }
                }
            }
        }

        private void GameLogic()
        {
            isGameWon = logic.CheckWin();
            if (isGameWon)
            {
                UIHelpers.ShowWin(!isXTurn);
                ResetGame();
                return;
            }
            if (logic.CheckDraw())
            {
                UIHelpers.ShowDraw();
                ResetGame();
                return;
            }
            UIHelpers.ShowPlayerTurn(isXTurn);
        }
    }
}
