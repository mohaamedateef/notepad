using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class notepad : Form
    {
        string path;
        public notepad()
        {
            InitializeComponent();
            path = null;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                rtb_data.SaveFile(saveFD.FileName);
                rtb_data.Clear();
                path = null;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                rtb_data.LoadFile(openFD.FileName);
                path = openFD.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path != null)
            {
                rtb_data.SaveFile(path);
                rtb_data.Clear();
                path = null;
            }
            else
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_data.Text != "")
            {
                if (MessageBox.Show("Do you need to save file?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }

            }
            path = null;
            rtb_data.Clear();

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontD.ShowDialog() == DialogResult.OK)
            {
                if (rtb_data.SelectedText != "")
                {
                    rtb_data.SelectionFont = fontD.Font;
                }
                else
                {
                    rtb_data.Font = fontD.Font;
                }
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorD.ShowDialog() == DialogResult.OK)
            {
                if (rtb_data.SelectedText != "")
                {
                    rtb_data.SelectionColor = colorD.Color;
                }
                else
                {
                    rtb_data.ForeColor = colorD.Color;
                }
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (colorD.ShowDialog() == DialogResult.OK)
                {
                    if (rtb_data.SelectedText != "")
                    {
                        rtb_data.SelectionBackColor = colorD.Color;
                    }
                    else
                    {
                        rtb_data.BackColor = colorD.Color;
                    }
                }
            }
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtb_data.Undo();

        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtb_data.Redo();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtb_data.Cut();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtb_data.Paste();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtb_data.SelectAll();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb_data.Copy();
        }
    }
}
