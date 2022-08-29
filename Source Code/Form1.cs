using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using SautinSoft.Document;

namespace ConvertWordToPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = @"DOCX Files (*.docx) | *.docx";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textPath.Text = System.IO.Path.GetFullPath(openFileDialog1.FileName);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            var wordFilename = textPath.Text;
            var pdfFilename = Path.GetFullPath(textPath.Text.Replace(".docx", ".pdf"));

            DocumentCore dc = DocumentCore.Load(wordFilename);
            dc.Save(pdfFilename);

            MessageBox.Show(pdfFilename + " generated successfully.");
        }
    }
}
