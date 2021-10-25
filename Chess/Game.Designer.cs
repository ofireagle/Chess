namespace Chess
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.turn_label = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developmentAndHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTheGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WhiteStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTimeWhite = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblErrorWhite = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrError = new System.Windows.Forms.Timer(this.components);
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.BlackStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTimeBlack = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblErrorBlack = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlPausePanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelOpeningGame = new System.Windows.Forms.Panel();
            this.buttonRules = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.buttonOpening = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.WhiteStatus.SuspendLayout();
            this.BlackStatus.SuspendLayout();
            this.pnlPausePanel.SuspendLayout();
            this.panelOpeningGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // turn_label
            // 
            this.turn_label.AutoSize = true;
            this.turn_label.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turn_label.Location = new System.Drawing.Point(220, 46);
            this.turn_label.Name = "turn_label";
            this.turn_label.Size = new System.Drawing.Size(0, 25);
            this.turn_label.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rulesToolStripMenuItem,
            this.developmentAndHistoryToolStripMenuItem,
            this.aboutTheGameToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
            // 
            // developmentAndHistoryToolStripMenuItem
            // 
            this.developmentAndHistoryToolStripMenuItem.Name = "developmentAndHistoryToolStripMenuItem";
            this.developmentAndHistoryToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.developmentAndHistoryToolStripMenuItem.Text = "development and history";
            this.developmentAndHistoryToolStripMenuItem.Click += new System.EventHandler(this.developmentAndHistoryToolStripMenuItem_Click);
            // 
            // aboutTheGameToolStripMenuItem
            // 
            this.aboutTheGameToolStripMenuItem.Name = "aboutTheGameToolStripMenuItem";
            this.aboutTheGameToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.aboutTheGameToolStripMenuItem.Text = "About the game";
            this.aboutTheGameToolStripMenuItem.Click += new System.EventHandler(this.aboutTheGameToolStripMenuItem_Click);
            // 
            // WhiteStatus
            // 
            this.WhiteStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTimeWhite,
            this.lblErrorWhite});
            this.WhiteStatus.Location = new System.Drawing.Point(0, 505);
            this.WhiteStatus.Name = "WhiteStatus";
            this.WhiteStatus.Size = new System.Drawing.Size(600, 22);
            this.WhiteStatus.TabIndex = 2;
            this.WhiteStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(41, 17);
            this.toolStripStatusLabel1.Text = "White:";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // lblTimeWhite
            // 
            this.lblTimeWhite.Name = "lblTimeWhite";
            this.lblTimeWhite.Size = new System.Drawing.Size(49, 17);
            this.lblTimeWhite.Text = "00:00:00";
            // 
            // lblErrorWhite
            // 
            this.lblErrorWhite.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblErrorWhite.Name = "lblErrorWhite";
            this.lblErrorWhite.Size = new System.Drawing.Size(0, 17);
            // 
            // tmrError
            // 
            this.tmrError.Interval = 3000;
            this.tmrError.Tick += new System.EventHandler(this.tmrError_Tick);
            // 
            // tmrTime
            // 
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // BlackStatus
            // 
            this.BlackStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.BlackStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.lblTimeBlack,
            this.lblErrorBlack});
            this.BlackStatus.Location = new System.Drawing.Point(0, 24);
            this.BlackStatus.Name = "BlackStatus";
            this.BlackStatus.Size = new System.Drawing.Size(600, 22);
            this.BlackStatus.TabIndex = 3;
            this.BlackStatus.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel2.Text = "Black:";
            this.toolStripStatusLabel2.ToolTipText = "הסטטוס בר מציג בעבור השחקן ה-שחור את: הזמן שלו, את חייליו שנאכלו,והודעות שגיאה בע" +
    "בורו.";
            // 
            // lblTimeBlack
            // 
            this.lblTimeBlack.Name = "lblTimeBlack";
            this.lblTimeBlack.Size = new System.Drawing.Size(49, 17);
            this.lblTimeBlack.Text = "00:00:00";
            // 
            // lblErrorBlack
            // 
            this.lblErrorBlack.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblErrorBlack.Name = "lblErrorBlack";
            this.lblErrorBlack.Size = new System.Drawing.Size(0, 17);
            // 
            // pnlPausePanel
            // 
            this.pnlPausePanel.Controls.Add(this.label4);
            this.pnlPausePanel.Controls.Add(this.label1);
            this.pnlPausePanel.Controls.Add(this.label2);
            this.pnlPausePanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlPausePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPausePanel.Location = new System.Drawing.Point(0, 0);
            this.pnlPausePanel.Name = "pnlPausePanel";
            this.pnlPausePanel.Size = new System.Drawing.Size(600, 527);
            this.pnlPausePanel.TabIndex = 6;
            this.pnlPausePanel.Visible = false;
            this.pnlPausePanel.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(172, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(414, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = ".המסך מוסתר לשם הוגנות המשחק במהלך השהייתו";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Click anywhere to go back...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.Click += new System.EventHandler(this.label2_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(365, 12);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(219, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "לחץ בכל מקום כדי לחזור...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panelOpeningGame
            // 
            this.panelOpeningGame.Controls.Add(this.buttonRules);
            this.panelOpeningGame.Controls.Add(this.pictureBox4);
            this.panelOpeningGame.Controls.Add(this.pictureBox5);
            this.panelOpeningGame.Controls.Add(this.pictureBox6);
            this.panelOpeningGame.Controls.Add(this.pictureBox7);
            this.panelOpeningGame.Controls.Add(this.buttonOpening);
            this.panelOpeningGame.Location = new System.Drawing.Point(0, 24);
            this.panelOpeningGame.Name = "panelOpeningGame";
            this.panelOpeningGame.Size = new System.Drawing.Size(600, 504);
            this.panelOpeningGame.TabIndex = 3;
            // 
            // buttonRules
            // 
            this.buttonRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRules.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.buttonRules.Location = new System.Drawing.Point(496, 25);
            this.buttonRules.Name = "buttonRules";
            this.buttonRules.Size = new System.Drawing.Size(90, 25);
            this.buttonRules.TabIndex = 33;
            this.buttonRules.Text = "חוקי המשחק";
            this.buttonRules.UseVisualStyleBackColor = true;
            this.buttonRules.Click += new System.EventHandler(this.buttonRules_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Enabled = false;
            this.pictureBox4.Image = global::Chess.Properties.Resources.BlackQueen;
            this.pictureBox4.Location = new System.Drawing.Point(41, 341);
            this.pictureBox4.MaximumSize = new System.Drawing.Size(100, 100);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 50);
            this.pictureBox4.TabIndex = 29;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Image = global::Chess.Properties.Resources.BlackKing;
            this.pictureBox5.Location = new System.Drawing.Point(41, 119);
            this.pictureBox5.MaximumSize = new System.Drawing.Size(100, 100);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 50);
            this.pictureBox5.TabIndex = 30;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Enabled = false;
            this.pictureBox6.Image = global::Chess.Properties.Resources.WhiteKing;
            this.pictureBox6.Location = new System.Drawing.Point(510, 119);
            this.pictureBox6.MaximumSize = new System.Drawing.Size(100, 100);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(50, 50);
            this.pictureBox6.TabIndex = 28;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Enabled = false;
            this.pictureBox7.Image = global::Chess.Properties.Resources.WhiteQueen;
            this.pictureBox7.Location = new System.Drawing.Point(510, 341);
            this.pictureBox7.MaximumSize = new System.Drawing.Size(100, 100);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(50, 50);
            this.pictureBox7.TabIndex = 31;
            this.pictureBox7.TabStop = false;
            // 
            // buttonOpening
            // 
            this.buttonOpening.AutoSize = true;
            this.buttonOpening.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpening.Font = new System.Drawing.Font("Guttman Mantova", 15F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonOpening.ForeColor = System.Drawing.Color.Red;
            this.buttonOpening.Image = global::Chess.Properties.Resources.ChessBoard1;
            this.buttonOpening.Location = new System.Drawing.Point(120, 88);
            this.buttonOpening.Name = "buttonOpening";
            this.buttonOpening.Size = new System.Drawing.Size(356, 356);
            this.buttonOpening.TabIndex = 32;
            this.buttonOpening.Text = "לחץ כדי להתחיל";
            this.buttonOpening.UseVisualStyleBackColor = true;
            this.buttonOpening.Click += new System.EventHandler(this.buttonOpening_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 527);
            this.Controls.Add(this.BlackStatus);
            this.Controls.Add(this.WhiteStatus);
            this.Controls.Add(this.turn_label);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelOpeningGame);
            this.Controls.Add(this.pnlPausePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(616, 566);
            this.Name = "Game";
            this.Text = "Chess Game";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.WhiteStatus.ResumeLayout(false);
            this.WhiteStatus.PerformLayout();
            this.BlackStatus.ResumeLayout(false);
            this.BlackStatus.PerformLayout();
            this.pnlPausePanel.ResumeLayout(false);
            this.pnlPausePanel.PerformLayout();
            this.panelOpeningGame.ResumeLayout(false);
            this.panelOpeningGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void toolStripStatusLabel1_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label turn_label;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip WhiteStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblTimeWhite;
        private System.Windows.Forms.ToolStripStatusLabel lblErrorWhite;
        private System.Windows.Forms.Timer tmrError;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.StatusStrip BlackStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblErrorBlack;
        private System.Windows.Forms.ToolStripStatusLabel lblTimeBlack;
        private System.Windows.Forms.Panel pnlPausePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.Panel panelOpeningGame;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button buttonOpening;
        private System.Windows.Forms.Button buttonRules;
        private System.Windows.Forms.ToolStripMenuItem developmentAndHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutTheGameToolStripMenuItem;
        private System.Windows.Forms.Label label4;

    }
}

