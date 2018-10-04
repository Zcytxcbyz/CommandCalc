using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Calc
{
    public partial class MainForm : Form
    {
        public bool isEditorMode = false;
        public static bool isOutputShow = false;
        public Output op;
        private void MainrichTextBox_TextChanged(object sender, EventArgs e)
        {
            CurrentState();          
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            FormLoad();
            LabelExplain.Text = "";
        }
        private void MainrichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            view(e);
            try
            {
                if (isEditorMode)
                {
                    if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
                    {
                        if (isOutputShow)
                        {
                            op.Activate();
                        }
                        else
                        {
                            isOutputShow = true;
                            op = new Output();
                            op.Show();
                        }
                        run(MainrichTextBox.Text, sender, e, op.OutputrichTextBox);
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        run(MainrichTextBox.Lines[line - 1], sender, e);
                    }
                }
            }
            catch(IndexOutOfRangeException)
            {

            }
            catch (Exception er)
            {
                MainrichTextBox.AppendText("\n" + er.Message);
            }
        }
        private void run(string input,object sender, EventArgs e,RichTextBox richtextbox)
        {
            try
            {
                string pattern = @"(?<!Math\.)(E|LN2|LN10|LOG2E|LOG10E|PI|SQRT1_2|SQRT2|abs|acos|asin|atan|atan2|ceil|cos|exp|floor|log|max|min|pow|random|round|sin|sqrt|tan)";
                MatchCollection mc = Regex.Matches(input, pattern);
                foreach (Match m in mc)
                {
                    Regex rgx = new Regex(pattern);
                    input = rgx.Replace(input, "Math." + m);
                }
                switch (input.TrimEnd(' '))
                {
                    case "help": helpToolStripMenuItem1_Click(sender, e); break;
                    case "exit": exitToolStripMenuItem_Click(sender, e); break;
                    case "save": saveToolStripMenuItem_Click(sender, e); break;
                    case "statusbar": statusBarToolStripMenuItem_Click(sender, e); break;
                    case "menubar": menuBarToolStripMenuItem_Click(sender, e); break;
                    case "clear": MainrichTextBox.Clear(); break;
                    default:
                        Microsoft.JScript.Vsa.VsaEngine ve = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
                        var result = Microsoft.JScript.Eval.JScriptEvaluate(input, ve);
                        richtextbox.AppendText("\n" + result.ToString());
                        break;
                }
            }
            catch (NullReferenceException)
            {

            }
            catch (Exception er)
            {
                richtextbox.AppendText("\n" + er.Message);
            }
        }
        private void run(string input, object sender, EventArgs e)
        {
            run(input, sender, e, MainrichTextBox);
        }
        public int NormalHeight, NormalWidth;
        public bool Maximized;
        public int line,column;
        public string cfgfilename =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CommandCalc.cfg";
        public MainForm()
        {
            InitializeComponent();
        }
        private void FormLoad()
        {
            //settingToolStripMenuItem0.Visible = false;
            CurrentState();
            if (File.Exists(cfgfilename))
            {
                string isMaximized = cfgRead("Maximized");
                if (isMaximized == "True" || isMaximized == "true")
                {
                    this.WindowState = FormWindowState.Maximized;
                    Maximized = true;
                }
                else
                {
                    Maximized = false;
                }
                if (cfgRead("StatusBar") == "True" || cfgRead("StatusBar") == "true")
                {
                    statusBarToolStripMenuItem.Checked = true;
                    MainstatusStrip.Visible = true;
                }
                else
                {
                    statusBarToolStripMenuItem.Checked = false;
                    MainstatusStrip.Visible = false;
                }
                if (cfgRead("MenuBar") == "True" || cfgRead("MenuBar") == "true")
                {
                    menuBarToolStripMenuItem.Checked = true;
                    MainmenuStrip.Visible = true;
                }
                else
                {
                    menuBarToolStripMenuItem.Checked = false;
                    MainmenuStrip.Visible = false;
                }
                NormalHeight = Convert.ToInt32(cfgRead("Height"));
                NormalWidth = Convert.ToInt32(cfgRead("Width"));
                this.Height = Convert.ToInt32(cfgRead("Height"));
                this.Width = Convert.ToInt32(cfgRead("Width"));
            }
            else
            {
                WriteFile(cfgfilename, "Height=" + this.Height.ToString());
                WriteFile(cfgfilename, "Width=" + this.Width.ToString());
                WriteFile(cfgfilename, "Height=" + this.Height.ToString());
                WriteFile(cfgfilename, "isMaximized=False");
                WriteFile(cfgfilename, "StatusBar=True");
                WriteFile(cfgfilename, "MenuBar=True");
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                cfgWrite("Height", this.Height.ToString());
                cfgWrite("Width", this.Width.ToString());
                cfgWrite("isMaximized", "False");
            }
            else
            {
                cfgWrite("Height", NormalHeight.ToString());
                cfgWrite("Width", NormalWidth.ToString());
                cfgWrite("isMaximized", "True");
            }
            cfgWrite("StatusBar", MainstatusStrip.Visible.ToString());
            cfgWrite("MenuBar", MainmenuStrip.Visible.ToString());
            if (isEditorMode)
            {
                if (MainrichTextBox.Text != "")
                {
                    DialogResult Result =
                        MessageBox.Show("是否保存", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Result == DialogResult.Yes)
                    {
                        saveToolStripMenuItem_Click(sender, e);
                    }
                }
            }
            Environment.Exit(0);
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                NormalHeight = this.Height;
                NormalWidth = this.Width;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                Maximized = true;
            }
        }
        private void Copy(object sender, EventArgs e) { MainrichTextBox.Copy(); }
        private void Cut(object sender, EventArgs e) { MainrichTextBox.Cut(); }
        private void Paste(object sender, EventArgs e) { MainrichTextBox.Paste(); }
        private void SelectAll(object sender, EventArgs e) { MainrichTextBox.SelectAll(); }
        private void Clear(object sender, EventArgs e) { MainrichTextBox.Clear(); }

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = MainrichTextBox.ForeColor;
            cd.ShowDialog();
            MainrichTextBox.ForeColor = cd.Color;
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = MainrichTextBox.BackColor;
            cd.ShowDialog();
            MainrichTextBox.BackColor = cd.Color;
        }

        private void fontStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = MainrichTextBox.Font; 
            fd.ShowDialog();
            MainrichTextBox.Font = fd.Font;
        }
        private void view(KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.M)
            {
                MainmenuStrip.Visible = true;
                menuBarToolStripMenuItem.Checked = true;
            }   
        }
        private void CurrentState()
        {
            int index = MainrichTextBox.GetFirstCharIndexOfCurrentLine();
            line = MainrichTextBox.GetLineFromCharIndex(index) + 1;
            column = MainrichTextBox.SelectionStart - index + 1;
            MaintoolStripStatusLabel.Text = "   lines:" + line.ToString() + "  columns:" + column.ToString();
        }
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked == true)
            {
                MainstatusStrip.Visible = false;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                MainstatusStrip.Visible = true;
                statusBarToolStripMenuItem.Checked = true;
            }
        }

        private void menuBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuBarToolStripMenuItem.Checked == true)
            {
                MainmenuStrip.Visible = false;
                menuBarToolStripMenuItem.Checked = false;
            }
            else
            {
                MainmenuStrip.Visible = true;
                menuBarToolStripMenuItem.Checked = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                cfgWrite("Height", this.Height.ToString());
                cfgWrite("Width", this.Width.ToString());
                cfgWrite("isMaximized", "False");
            }
            else
            {
                cfgWrite("Height", NormalHeight.ToString());
                cfgWrite("Width", NormalWidth.ToString());
                cfgWrite("isMaximized", "True");
            }
            cfgWrite("StatusBar", MainstatusStrip.Visible.ToString());
            cfgWrite("MenuBar", MainmenuStrip.Visible.ToString());
            if (isEditorMode)
            {
                if (MainrichTextBox.Text != "")
                {
                    DialogResult Result =
                        MessageBox.Show("是否保存", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Result == DialogResult.Yes)
                    {
                        saveToolStripMenuItem_Click(sender, e);
                    }
                }
            }
            Environment.Exit(0);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                WriteFile(sfd.FileName.ToString(), MainrichTextBox.Text.Replace("\n", "\r\n"));
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MainrichTextBox.Text = ReadFile(ofd.FileName);
            }
        }
        public void CreateFile(string path, string str)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public void WriteFile(string path, string str)
        {
            FileStream fs = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public string ReadFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string str = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return str;
        }
        public void cfgWrite(string name, string value)
        {
            Regex rgx = new Regex("(?<=" + name + "=).*");
            string str = rgx.Replace(ReadFile(cfgfilename), value);
            CreateFile(cfgfilename, str.Replace("\n", "\r\n"));
        }
        public string cfgRead(string name)
        {
            Match mc = Regex.Match(ReadFile(cfgfilename), "(?<=" + name + "=).*");
            mc.ToString();
            return mc.ToString().Replace("\r", "");
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Help().ShowDialog();
        }

        private void editorModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editorModeToolStripMenuItem.Checked == true) 
            {
                isEditorMode = false;
                editorModeToolStripMenuItem.Checked = false;
                openToolStripMenuItem.Enabled = false;
                LabelExplain.Text = "";
                if (MainrichTextBox.Text != "")
                {
                    DialogResult Result =
                        MessageBox.Show("是否保存", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Result == DialogResult.Yes)
                    {
                        saveToolStripMenuItem_Click(sender, e);
                    }
                }
                MainrichTextBox.Clear();
            }
            else
            {
                isEditorMode = true;
                editorModeToolStripMenuItem.Checked = true;
                MainrichTextBox.Clear();
                openToolStripMenuItem.Enabled = true;
                LabelExplain.Text = "   当前处于编辑器模式,若要执行请按\"Ctrl+Enter\"";
            }    
        }
        private void runToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isEditorMode)
                {
                    if (isOutputShow)
                    {
                        op.Activate();
                    }
                    else
                    {
                        isOutputShow = true;
                        op = new Output();
                        op.Show();
                    }
                    run(MainrichTextBox.Text, sender, e, op.OutputrichTextBox);
                }
                else
                {
                    run(MainrichTextBox.Lines[line - 1], sender, e);
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
            catch (Exception er)
            {
                MainrichTextBox.AppendText("\n" + er.Message);
            }
        }
    }
}
