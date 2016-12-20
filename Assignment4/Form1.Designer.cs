namespace Assignment4
{
    partial class MyForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.initialiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initializeShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyTransformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panShape1 = new System.Windows.Forms.Panel();
            this.panShape2 = new System.Windows.Forms.Panel();
            this.applyTransformation2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initialiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1263, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // initialiToolStripMenuItem
            // 
            this.initialiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializeShapesToolStripMenuItem,
            this.applyTransformationToolStripMenuItem,
            this.applyTransformation2ToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.initialiToolStripMenuItem.Name = "initialiToolStripMenuItem";
            this.initialiToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.initialiToolStripMenuItem.Text = "File";
            // 
            // initializeShapesToolStripMenuItem
            // 
            this.initializeShapesToolStripMenuItem.Name = "initializeShapesToolStripMenuItem";
            this.initializeShapesToolStripMenuItem.Size = new System.Drawing.Size(268, 30);
            this.initializeShapesToolStripMenuItem.Text = "Initialize Shapes";
            this.initializeShapesToolStripMenuItem.Click += new System.EventHandler(this.initializeShapesToolStripMenuItem_Click);
            // 
            // applyTransformationToolStripMenuItem
            // 
            this.applyTransformationToolStripMenuItem.Name = "applyTransformationToolStripMenuItem";
            this.applyTransformationToolStripMenuItem.Size = new System.Drawing.Size(268, 30);
            this.applyTransformationToolStripMenuItem.Text = "Apply Transformation";
            this.applyTransformationToolStripMenuItem.Click += new System.EventHandler(this.applyTransformationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(268, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panShape1
            // 
            this.panShape1.Location = new System.Drawing.Point(21, 71);
            this.panShape1.Name = "panShape1";
            this.panShape1.Size = new System.Drawing.Size(604, 816);
            this.panShape1.TabIndex = 1;
            // 
            // panShape2
            // 
            this.panShape2.Location = new System.Drawing.Point(664, 71);
            this.panShape2.Name = "panShape2";
            this.panShape2.Size = new System.Drawing.Size(605, 816);
            this.panShape2.TabIndex = 2;
            // 
            // applyTransformation2ToolStripMenuItem
            // 
            this.applyTransformation2ToolStripMenuItem.Name = "applyTransformation2ToolStripMenuItem";
            this.applyTransformation2ToolStripMenuItem.Size = new System.Drawing.Size(278, 30);
            this.applyTransformation2ToolStripMenuItem.Text = "Apply Transformation2";
            this.applyTransformation2ToolStripMenuItem.Click += new System.EventHandler(this.applyTransformation2ToolStripMenuItem_Click);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 920);
            this.Controls.Add(this.panShape2);
            this.Controls.Add(this.panShape1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MyForm";
            this.Text = "Assignment4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem initialiToolStripMenuItem;
        private System.Windows.Forms.Panel panShape1;
        private System.Windows.Forms.Panel panShape2;
        private System.Windows.Forms.ToolStripMenuItem initializeShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyTransformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyTransformation2ToolStripMenuItem;
    }
}

