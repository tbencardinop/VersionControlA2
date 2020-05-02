//*****************************************************************************
// Programmer: Tatiana Bencardino
// Date: 30 April 2020
// Software: Microsoft Visual Studio 2019 Community Edition
// Platform: Microsoft Windows 10 Professional 64­bit
// Purpose: Drag & drop of a file from Windows Explorer to a picture box
//*****************************************************************************


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragNDrop
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;      //Enable drag and drop for this form
            this.DragEnter += new DragEventHandler(frmMain_DragEnter);  //Event handler for drag enter
            this.DragDrop += new DragEventHandler(frmMain_DragDrop);    //Event handler for drag drop
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileName = data as string[];
                if (fileName.Length > 0)
                    picDrop.Image = Image.FromFile(fileName[0]);
            }
        }
    }
}
