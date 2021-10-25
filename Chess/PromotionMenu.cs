using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class PromotionMenu : Form
    {
        public Piece ChosenPiece { get; private set; } // הכלי שנבחר שיחליף את הרגלי
        public PromotionMenu(PieceColor color)
        {
            InitializeComponent();

            var strip = new Panel(); // יצרת הפאנל שיכיל את הכפתורים
            // הוספה לפאנל הכפתורים כפתור עם כל אפשרות לחייל וגם יצירת סוג החייל לפי הכפתור
            strip.Controls.AddRange(new Control[]{ 
                new Label(){Image = Pictures.Pieces_Pictures.GetPicture(Enum.GetName(color.GetType(), color) + "Queen"), Tag = new Queen(color)},
                new Label(){Image = Pictures.Pieces_Pictures.GetPicture(Enum.GetName(color.GetType(), color) + "Rook"), Tag = new Rook(color)},
                new Label(){Image = Pictures.Pieces_Pictures.GetPicture(Enum.GetName(color.GetType(), color) + "Bishop"), Tag = new Bishop(color)},
                new Label(){Image = Pictures.Pieces_Pictures.GetPicture(Enum.GetName(color.GetType(), color) + "Knight"), Tag = new Knight(color)}});

            strip.Location = new Point(0, 25); // מיקום הפאנל
            strip.Size = new Size(200, 50); // גודל הפאנל
            for (int i = 0; i < strip.Controls.Count; i++) // עבור כל אחד מהלחצנים
            {
                var item = strip.Controls[i]; // שימת הלחצן
                item.Click += item_Click; // הרשמה לאירוע הלחיצה
                item.Location = new Point(i * 50, 0); // מיקום הלחצן בהתאם למיקום הסידורי שלו
                item.Size = new Size(50, 50); // גודל הלחצן
            }
            this.Controls.Add(strip); // הוספת הפאנל עצמו לטופס
        }

        // אירוע הלחיצה
        void item_Click(object sender, EventArgs e)
        {
            this.ChosenPiece = ((Label)sender).Tag as Piece; // שימת החייל בתוך החייל הנבחר לשם החלפתו במשחק
            this.Close(); // סגירת הטופס
        }
    }
}
