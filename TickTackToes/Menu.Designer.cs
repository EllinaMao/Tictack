namespace TickTackToes
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartSoloGame = new Button();
            StartMultiplayer = new Button();
            Exit = new Button();
            SuspendLayout();
            // 
            // StartSoloGame
            // 
            StartSoloGame.BackColor = Color.DarkSeaGreen;
            StartSoloGame.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartSoloGame.Location = new Point(492, 223);
            StartSoloGame.Name = "StartSoloGame";
            StartSoloGame.Size = new Size(162, 31);
            StartSoloGame.TabIndex = 0;
            StartSoloGame.Text = "Solo game";
            StartSoloGame.UseVisualStyleBackColor = false;
            StartSoloGame.Click += SoloGameClick;
            // 
            // StartMultiplayer
            // 
            StartMultiplayer.Location = new Point(492, 291);
            StartMultiplayer.Name = "StartMultiplayer";
            StartMultiplayer.Size = new Size(162, 31);
            StartMultiplayer.TabIndex = 1;
            StartMultiplayer.Text = "Multiplayer(local)";
            StartMultiplayer.UseVisualStyleBackColor = true;
            StartMultiplayer.Click += StartMultiplayer_Click;
            // 
            // Exit
            // 
            Exit.Location = new Point(492, 360);
            Exit.Name = "Exit";
            Exit.Size = new Size(162, 29);
            Exit.TabIndex = 2;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._8339bec72f606bb96256b486fe867580;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1129, 697);
            Controls.Add(Exit);
            Controls.Add(StartMultiplayer);
            Controls.Add(StartSoloGame);
            Name = "Menu";
            Text = "TickTackToe";
            ResumeLayout(false);
        }

        #endregion

        private Button StartSoloGame;
        private Button StartMultiplayer;
        private Button Exit;

    }
}