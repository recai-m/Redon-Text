using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redon_Text
{
    public partial class RedonText : Form
    {
        public RedonText()
        {
            InitializeComponent();
        }

        private async void openToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog File = new OpenFileDialog() {Filter="Text Files|*.txt",Multiselect=false,ValidateNames=true})
                {
                    if (File.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamReader StR = new StreamReader(File.FileName))
                        {
                            Text.Text = await StR.ReadToEndAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog FoD = new FontDialog();
            if(FoD.ShowDialog() == DialogResult.OK)
            {
                Text.Font = FoD.Font;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About A = new About();
            A.ShowDialog();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text.Text = "";
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog CoD = new ColorDialog();
            if (CoD.ShowDialog() == DialogResult.OK)
            {
                Text.ForeColor = CoD.Color;
            }
        }

        private void changeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog CoD = new ColorDialog();
            if (CoD.ShowDialog() == DialogResult.OK)
            {
                Text.BackColor = CoD.Color;
            }
        }
    }
}
