using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

namespace AMS_RFID_V2
{
    public partial class SupportingWinform : Form
    {
        public SupportingWinform()
        {
            InitializeComponent();
            printdoc11.PrintPage += new PrintPageEventHandler(printdoc11_PrintPage);

        }

        private void SupportingWinform_Load(object sender, EventArgs e)
        {

        }
        PrintDocument printdoc11 = new PrintDocument();
        PrintPreviewDialog previewdlg = new PrintPreviewDialog();
        Panel pannel = null;
        //declare event handler for printing in constructor

        //Rest of the code
        Bitmap MemoryImage;
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        void printdoc11_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.guna2Panel1.Width / 2), this.guna2Panel1.Location.Y);
        }
        public void Print(Panel pnl)
        {
            pannel = pnl;
            GetPrintArea(pnl);
            previewdlg.Document = printdoc11;
            previewdlg.ShowDialog();
        }
        private void ForPrint_Click(object sender, EventArgs e)
        {
            Print(this.guna2Panel1);
        }


    }
}
