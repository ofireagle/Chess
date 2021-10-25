namespace Chess
{
    partial class Rules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rules));
            this.label1 = new System.Windows.Forms.Label();
            this.turn_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBoxQueen = new System.Windows.Forms.PictureBox();
            this.pictureBoxKnight = new System.Windows.Forms.PictureBox();
            this.pictureBoxRook = new System.Windows.Forms.PictureBox();
            this.pictureBoxPawn = new System.Windows.Forms.PictureBox();
            this.pictureBoxBishop = new System.Windows.Forms.PictureBox();
            this.pictureBoxKing = new System.Windows.Forms.PictureBox();
            this.rtbMainBox = new System.Windows.Forms.RichTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPawn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKing)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 43);
            this.label1.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "לחץ על תמונת חייל מסוים לפרטים עליו";
            // 
            // turn_label
            // 
            this.turn_label.AutoSize = true;
            this.turn_label.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turn_label.Location = new System.Drawing.Point(193, 13);
            this.turn_label.Name = "turn_label";
            this.turn_label.Size = new System.Drawing.Size(61, 25);
            this.turn_label.TabIndex = 8;
            this.turn_label.Text = "חוקים";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 422);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "לפרטים נוספים:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(351, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "en-passant";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.PictureBoxClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Harlow Solid Italic", 8.25F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(345, 156);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "חוקים מיוחדים:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(351, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "הכתרה";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.PictureBoxClicked);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(351, 244);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "הצרחה";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.PictureBoxClicked);
            // 
            // pictureBoxQueen
            // 
            this.pictureBoxQueen.Location = new System.Drawing.Point(306, 88);
            this.pictureBoxQueen.Name = "pictureBoxQueen";
            this.pictureBoxQueen.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxQueen.TabIndex = 7;
            this.pictureBoxQueen.TabStop = false;
            this.pictureBoxQueen.Click += new System.EventHandler(this.PictureBoxClicked);
            // 
            // pictureBoxKnight
            // 
            this.pictureBoxKnight.Location = new System.Drawing.Point(166, 88);
            this.pictureBoxKnight.Name = "pictureBoxKnight";
            this.pictureBoxKnight.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxKnight.TabIndex = 6;
            this.pictureBoxKnight.TabStop = false;
            this.pictureBoxKnight.Click += new System.EventHandler(this.PictureBoxClicked);
            // 
            // pictureBoxRook
            // 
            this.pictureBoxRook.Location = new System.Drawing.Point(95, 88);
            this.pictureBoxRook.Name = "pictureBoxRook";
            this.pictureBoxRook.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxRook.TabIndex = 5;
            this.pictureBoxRook.TabStop = false;
            this.pictureBoxRook.Click += new System.EventHandler(this.PictureBoxClicked);
            // 
            // pictureBoxPawn
            // 
            this.pictureBoxPawn.Location = new System.Drawing.Point(24, 88);
            this.pictureBoxPawn.Name = "pictureBoxPawn";
            this.pictureBoxPawn.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxPawn.TabIndex = 4;
            this.pictureBoxPawn.TabStop = false;
            this.pictureBoxPawn.Click += new System.EventHandler(this.PictureBoxClicked);
            // 
            // pictureBoxBishop
            // 
            this.pictureBoxBishop.Location = new System.Drawing.Point(234, 88);
            this.pictureBoxBishop.Name = "pictureBoxBishop";
            this.pictureBoxBishop.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxBishop.TabIndex = 3;
            this.pictureBoxBishop.TabStop = false;
            this.pictureBoxBishop.Click += new System.EventHandler(this.PictureBoxClicked);
            // 
            // pictureBoxKing
            // 
            this.pictureBoxKing.Location = new System.Drawing.Point(376, 88);
            this.pictureBoxKing.Name = "pictureBoxKing";
            this.pictureBoxKing.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxKing.TabIndex = 1;
            this.pictureBoxKing.TabStop = false;
            this.pictureBoxKing.Click += new System.EventHandler(this.PictureBoxClicked);
            // 
            // rtbMainBox
            // 
            this.rtbMainBox.Font = new System.Drawing.Font("Guttman Mantova", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rtbMainBox.Location = new System.Drawing.Point(24, 156);
            this.rtbMainBox.Name = "rtbMainBox";
            this.rtbMainBox.ReadOnly = true;
            this.rtbMainBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtbMainBox.Size = new System.Drawing.Size(310, 248);
            this.rtbMainBox.TabIndex = 16;
            this.rtbMainBox.Text = resources.GetString("rtbMainBox.Text");
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(127, 422);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(207, 13);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://www.ichess.co.il/article.html#!id=8";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(21, 435);
            this.linkLabel2.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(313, 13);
            this.linkLabel2.TabIndex = 18;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://he.wikipedia.org/wiki/%D7%A9%D7%97%D7%9E%D7%98";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Rules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 474);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.rtbMainBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.turn_label);
            this.Controls.Add(this.pictureBoxQueen);
            this.Controls.Add(this.pictureBoxKnight);
            this.Controls.Add(this.pictureBoxRook);
            this.Controls.Add(this.pictureBoxPawn);
            this.Controls.Add(this.pictureBoxBishop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxKing);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Rules";
            this.Text = "חוקים";
            this.Click += new System.EventHandler(this.Rules_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPawn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxKing;
        private System.Windows.Forms.PictureBox pictureBoxBishop;
        private System.Windows.Forms.PictureBox pictureBoxPawn;
        private System.Windows.Forms.PictureBox pictureBoxRook;
        private System.Windows.Forms.PictureBox pictureBoxKnight;
        private System.Windows.Forms.PictureBox pictureBoxQueen;
        private System.Windows.Forms.Label turn_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox rtbMainBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}