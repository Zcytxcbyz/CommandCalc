using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Output : Form
    {
        public Output()
        {
            InitializeComponent();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OutputrichTextBox.Copy();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OutputrichTextBox.SelectAll();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutputrichTextBox.Clear();
        }

        private void Output_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.isOutputShow = false;
        }
    }
}
