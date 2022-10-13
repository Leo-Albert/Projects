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

namespace Leo_Notepad
{
    public partial class mainform : Form
    {
        string path;
        StreamWriter sw;
        int i = 1;
        public mainform()
        {
            InitializeComponent();
        }
        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainform m = new mainform();
            m.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textarea.Clear();
            this.Text = "Untitled Leo Notepad";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (opendialog.ShowDialog()== DialogResult.OK) {
                path = opendialog.FileName;
                
                try
                {
                    StreamReader r = new StreamReader(path);
                    textarea.Text = r.ReadToEnd();
                    this.Text = Path.GetFileNameWithoutExtension(path) + "  Leo Notepad";
                    r.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message ,"File Cannot Open",MessageBoxButtons.OK ,MessageBoxIcon.Error );
                    this.Text = "Untitled Leo Notepad";
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.Text == "* Untitled Leo Notepad")
            {
                if (path == null)
                {
                    savefile();
                }
                else
                {
                    sw = new StreamWriter(path);
                    sw.WriteLine(textarea.Text);
                    this.Text = Path.GetFileNameWithoutExtension(path) + " Leo Notepad";
                    sw.Flush();
                    sw.Close();
                }

            }
            else
            {
                sw = new StreamWriter(path);
                sw.WriteLine(textarea.Text);
                this.Text = Path.GetFileNameWithoutExtension(path) + " Leo Notepad";
                sw.Flush();
                sw.Close();
            }

        }
        void savefile()
        {
            if (savedialog .ShowDialog ()== DialogResult.OK ) {
                path = savedialog.FileName;
                this.Text = Path.GetFileNameWithoutExtension(path) + " Leo Notepad";
                sw = new StreamWriter(File.Create(path));
                sw.WriteLine(textarea.Text);
                sw.Flush();
                sw.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();       
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printdialog.ShowDialog();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pagesetupdialog .PageSettings = new System.Drawing.Printing.PageSettings();
            DialogResult result = pagesetupdialog .ShowDialog();
            
        }

        private void cutmenu_Click(object sender, EventArgs e)
        {
            textarea.Cut();
        }

        private void copymenu_Click(object sender, EventArgs e)
        {
            textarea.Copy();
        }

        private void pastemenu_Click(object sender, EventArgs e)
        {
            textarea.Paste();
        }

        private void deletemenu_Click(object sender, EventArgs e)
        {
            textarea.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textarea.SelectAll();
        }

        private void timedateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now ;
            string datetime=now.ToString();

            textarea.AppendText(datetime);
        }

        private void undomenu_Click(object sender, EventArgs e)
        {
            
            if (i==1) {
                textarea.Undo();
            }
            else
            {
                textarea.Redo();
            }
            if (i == 1)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
           
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textarea .WordWrap ==true)
            {
                textarea.WordWrap = false;
            }
            else
            {
                textarea.WordWrap = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontdialog .ShowDialog()==DialogResult.OK)
            {
                textarea.Font = fontdialog.Font;
            }
        }

        private void backcolor_Click(object sender, EventArgs e)
        {
            if(colordialog .ShowDialog ()== DialogResult.OK)
            {
                textarea.BackColor = colordialog.Color;
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textarea.ZoomFactor += 1;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textarea.ZoomFactor > 1)
            {
                textarea.ZoomFactor -= 1;
            }
        }

        private void defaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textarea.ZoomFactor = 1;
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(fontdialog .ShowDialog() == DialogResult.OK)
            {
                textarea.SelectionFont = fontdialog.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colordialog .ShowDialog ()==DialogResult.OK) {
                textarea.SelectionColor = colordialog.Color;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colordialog .ShowDialog ()==DialogResult.OK ) {
                textarea.SelectionBackColor = colordialog.Color;
            }
        }

        private void textarea_TextChanged(object sender, EventArgs e)
        {
            
            
                this.Text = "* Untitled Leo Notepad";
            
            
        }

        private void textarea_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void textarea_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(textarea .SelectedText != "") {
                cutmenu.Enabled = true;
                copymenu.Enabled = true;
                deletemenu.Enabled = true;
            }
            else
            {
                cutmenu.Enabled = false;
                copymenu.Enabled = false;
                deletemenu.Enabled = false;
            }
        }

        private void textarea_SelectionChanged(object sender, EventArgs e)
        {
            if (textarea.SelectedText != "")
            {
                cutmenu.Enabled = true;
                copymenu.Enabled = true;
                deletemenu.Enabled = true;
            }
            else
            {
                cutmenu.Enabled = false;
                copymenu.Enabled = false;
                deletemenu.Enabled = false;
            }
        }

        private void textarea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System .Windows .Forms .MouseButtons .Right)
            {
                contextMenu.Show(Cursor .Position );
            }
            

            
        }
    }
}

