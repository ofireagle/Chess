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
    public delegate void GraphicCellWasPressed(Cell cell);
    public class GraphicCell : Button // תא גרפי , יורש מכפתור , מהווה תא בלוח הגרפי שעל טופס המשחק.
    {
        private int _size;
        public int CellSize
        {
            get { return _size; }
            set
            {
                this._size = value;
                this.ResizeCell(value, value);
                this.Relocate(this.Cell.J * value , this.Cell.I * value);
            }
        }
        public event GraphicCellWasPressed GraphicCellWasPressed;
        private Color UnderThreatColor;
        private Color StandardColor;
        private Color MarkedColor;
        private Cell Cell { get; set; }

        // בנאי ברירת מחדל- מאתחל את תכונות המחלקה המייצגת תא גרפי , ביניהם גודל התא , וסגנונו (מאחר ויורשת מכפתור) .

        public GraphicCell(Cell cell, int size)
        {
            this.Cell = cell; // התא המתקבל כתכונה אצל התא הגרפי

            MarkedColor = Color.BlueViolet; // צבע של סימון יהיה כחול
            UnderThreatColor = Color.OrangeRed; // צבע של איום יהיה כתום

            this.StandardColor = cell.I % 2 == cell.J % 2  // קביעת הצבע חום או לבן בהתאם למיקום התא - זוגי אי זוגי
                ? StandardColor = Color.White            
                : StandardColor = Color.SandyBrown;           

            this.SetColorAsStandard(); // הפיכת הצבע לסטנדרטי
            this.FlatStyle = FlatStyle.Flat; // כל תא גרפי יהיה בסגנון שטוח
            this.UseVisualStyleBackColor = true; 
            this.Click += new System.EventHandler(this.OnClick); // הרשמה של הפונקציה קליק לאירוע
            this.CellSize = size; // עדכון גודל התא
        }

        public GraphicCell(Cell cell) : this(cell, 50) { }

        // פונקציה המעדכנת את מיקום התא הגרפי.
        private void Relocate(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        // פונקציה המשנה את גודל התא הגרפי.
        public void ResizeCell(int width, int height)
        {
            this.Size = new Size(width, height);
        }

        // מאורע לחיצה שכאשר לוחצים על התא הגרפי מופעל אם נרשמו למאורע GraphicCellWasPresse, המאורע GraphicCellWasPressed יוקפץ .
        private void OnClick(object sender, EventArgs e)
        {
            if (this.GraphicCellWasPressed != null) // אם נרשמו לאירוע
            {
                this.GraphicCellWasPressed(this.Cell); // להפעיל את כל הפונקציות שנרשמו לאירוע לחיצה
            }
        }

        // הפונקציה מעדכנת את צבע התא הגרפי להיות הצבע הסטנדרטי .
        public void SetColorAsStandard()
        {
            this.BackColor = this.StandardColor; // צבע רקע הופך לסטנדרטי
        }

        // הפונקציה משנה את צבע התא הגרפי להיות צבע של תא גרפי מסומן. (שניתן לעשות מהלך אליו.
        public void SetColorAsMarked()
        {
            this.BackColor = this.MarkedColor; // צבע רקע הופך למסומן
        }

        // הפונקציה מבטלת את הסימון של התא אם מסומן.
        public void UnmarkIfMarked()
        {
            if (this.BackColor == this.MarkedColor) // אם מסומן
            {
                this.SetColorAsStandard(); // תחזיר לסטנדרטי
            }
        }

        // הפונקציה מעדכנת את צבע התא הגרפי הנ"ל להיות בצבע של "שח" .
        public void SetColorAsUnderCheck()
        {
            this.BackColor = this.UnderThreatColor; // צבע רקע הופך למאוים
        }
    }
}
