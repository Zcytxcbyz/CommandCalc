namespace Calc
{
    partial class Output
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OutputrichTextBox = new System.Windows.Forms.RichTextBox();
            this.MaincontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaincontextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputrichTextBox
            // 
            this.OutputrichTextBox.ContextMenuStrip = this.MaincontextMenuStrip;
            this.OutputrichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputrichTextBox.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OutputrichTextBox.Location = new System.Drawing.Point(0, 0);
            this.OutputrichTextBox.Name = "OutputrichTextBox";
            this.OutputrichTextBox.ReadOnly = true;
            this.OutputrichTextBox.Size = new System.Drawing.Size(509, 461);
            this.OutputrichTextBox.TabIndex = 0;
            this.OutputrichTextBox.Text = "";
            this.OutputrichTextBox.WordWrap = false;
            // 
            // MaincontextMenuStrip
            // 
            this.MaincontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.selectAllToolStripMenuItem1,
            this.clearToolStripMenuItem});
            this.MaincontextMenuStrip.Name = "MaincontextMenuStrip";
            this.MaincontextMenuStrip.Size = new System.Drawing.Size(101, 70);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.copyToolStripMenuItem1.Text = "复制";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // selectAllToolStripMenuItem1
            // 
            this.selectAllToolStripMenuItem1.Name = "selectAllToolStripMenuItem1";
            this.selectAllToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.selectAllToolStripMenuItem1.Text = "全选";
            this.selectAllToolStripMenuItem1.Click += new System.EventHandler(this.selectAllToolStripMenuItem1_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.clearToolStripMenuItem.Text = "清空";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 461);
            this.Controls.Add(this.OutputrichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Output";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "输出";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Output_FormClosing);
            this.MaincontextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox OutputrichTextBox;
        private System.Windows.Forms.ContextMenuStrip MaincontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}