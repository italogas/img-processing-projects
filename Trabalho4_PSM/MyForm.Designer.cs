namespace ImageProcessingAssignments
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
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.load2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differentiateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xDirectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yDirectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonMaximumSupressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleThresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picOrigImage = new System.Windows.Forms.PictureBox();
            this.lblImageUnderTest = new System.Windows.Forms.Label();
            this.picEditedImage = new System.Windows.Forms.PictureBox();
            this.inputImgDimensionsLabel = new System.Windows.Forms.Label();
            this.outputImgDimensionsLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOrigImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEditedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1902, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.load2ToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(87, 29);
            this.loadToolStripMenuItem.Text = "Arquivo";
            // 
            // load2ToolStripMenuItem
            // 
            this.load2ToolStripMenuItem.Name = "load2ToolStripMenuItem";
            this.load2ToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.load2ToolStripMenuItem.Text = "Carregar base de dados";
            this.load2ToolStripMenuItem.Click += new System.EventHandler(this.load2ToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(286, 30);
            this.exitToolStripMenuItem.Text = "Sair";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothingToolStripMenuItem,
            this.differentiateToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.editToolStripMenuItem.Text = "Editar";
            // 
            // smoothingToolStripMenuItem
            // 
            this.smoothingToolStripMenuItem.Name = "smoothingToolStripMenuItem";
            this.smoothingToolStripMenuItem.Size = new System.Drawing.Size(309, 30);
            this.smoothingToolStripMenuItem.Text = "Histograma Cores de cinza";
            this.smoothingToolStripMenuItem.Click += new System.EventHandler(this.smoothingToolStripMenuItem_Click);
            // 
            // differentiateToolStripMenuItem
            // 
            this.differentiateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xDirectionToolStripMenuItem,
            this.yDirectionToolStripMenuItem,
            this.bothToolStripMenuItem,
            this.nonMaximumSupressionToolStripMenuItem,
            this.doubleThresholdingToolStripMenuItem});
            this.differentiateToolStripMenuItem.Name = "differentiateToolStripMenuItem";
            this.differentiateToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.differentiateToolStripMenuItem.Text = "Differentiate";
            // 
            // xDirectionToolStripMenuItem
            // 
            this.xDirectionToolStripMenuItem.Name = "xDirectionToolStripMenuItem";
            this.xDirectionToolStripMenuItem.Size = new System.Drawing.Size(305, 30);
            this.xDirectionToolStripMenuItem.Text = "X direction";
            this.xDirectionToolStripMenuItem.Click += new System.EventHandler(this.xDirectionToolStripMenuItem_Click);
            // 
            // yDirectionToolStripMenuItem
            // 
            this.yDirectionToolStripMenuItem.Name = "yDirectionToolStripMenuItem";
            this.yDirectionToolStripMenuItem.Size = new System.Drawing.Size(305, 30);
            this.yDirectionToolStripMenuItem.Text = "Y direction";
            this.yDirectionToolStripMenuItem.Click += new System.EventHandler(this.yDirectionToolStripMenuItem_Click);
            // 
            // bothToolStripMenuItem
            // 
            this.bothToolStripMenuItem.Name = "bothToolStripMenuItem";
            this.bothToolStripMenuItem.Size = new System.Drawing.Size(305, 30);
            this.bothToolStripMenuItem.Text = "Both";
            this.bothToolStripMenuItem.Click += new System.EventHandler(this.bothToolStripMenuItem_Click);
            // 
            // nonMaximumSupressionToolStripMenuItem
            // 
            this.nonMaximumSupressionToolStripMenuItem.Name = "nonMaximumSupressionToolStripMenuItem";
            this.nonMaximumSupressionToolStripMenuItem.Size = new System.Drawing.Size(305, 30);
            this.nonMaximumSupressionToolStripMenuItem.Text = "Non maximum supression";
            this.nonMaximumSupressionToolStripMenuItem.Click += new System.EventHandler(this.nonMaximumSupressionToolStripMenuItem_Click);
            // 
            // doubleThresholdingToolStripMenuItem
            // 
            this.doubleThresholdingToolStripMenuItem.Name = "doubleThresholdingToolStripMenuItem";
            this.doubleThresholdingToolStripMenuItem.Size = new System.Drawing.Size(305, 30);
            this.doubleThresholdingToolStripMenuItem.Text = "Double Thresholding";
            this.doubleThresholdingToolStripMenuItem.Click += new System.EventHandler(this.doubleThresholdingToolStripMenuItem_Click);
            // 
            // picOrigImage
            // 
            this.picOrigImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOrigImage.Location = new System.Drawing.Point(12, 92);
            this.picOrigImage.Name = "picOrigImage";
            this.picOrigImage.Size = new System.Drawing.Size(847, 888);
            this.picOrigImage.TabIndex = 1;
            this.picOrigImage.TabStop = false;
            // 
            // lblImageUnderTest
            // 
            this.lblImageUnderTest.AutoSize = true;
            this.lblImageUnderTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageUnderTest.Location = new System.Drawing.Point(28, 67);
            this.lblImageUnderTest.Name = "lblImageUnderTest";
            this.lblImageUnderTest.Size = new System.Drawing.Size(0, 20);
            this.lblImageUnderTest.TabIndex = 2;
            // 
            // picEditedImage
            // 
            this.picEditedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEditedImage.Location = new System.Drawing.Point(893, 92);
            this.picEditedImage.Name = "picEditedImage";
            this.picEditedImage.Size = new System.Drawing.Size(847, 888);
            this.picEditedImage.TabIndex = 3;
            this.picEditedImage.TabStop = false;
            // 
            // inputImgDimensionsLabel
            // 
            this.inputImgDimensionsLabel.AutoSize = true;
            this.inputImgDimensionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputImgDimensionsLabel.Location = new System.Drawing.Point(608, 983);
            this.inputImgDimensionsLabel.Name = "inputImgDimensionsLabel";
            this.inputImgDimensionsLabel.Size = new System.Drawing.Size(0, 20);
            this.inputImgDimensionsLabel.TabIndex = 4;
            // 
            // outputImgDimensionsLabel
            // 
            this.outputImgDimensionsLabel.AutoSize = true;
            this.outputImgDimensionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputImgDimensionsLabel.Location = new System.Drawing.Point(1489, 983);
            this.outputImgDimensionsLabel.Name = "outputImgDimensionsLabel";
            this.outputImgDimensionsLabel.Size = new System.Drawing.Size(0, 20);
            this.outputImgDimensionsLabel.TabIndex = 6;
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1902, 1028);
            this.Controls.Add(this.outputImgDimensionsLabel);
            this.Controls.Add(this.inputImgDimensionsLabel);
            this.Controls.Add(this.picEditedImage);
            this.Controls.Add(this.lblImageUnderTest);
            this.Controls.Add(this.picOrigImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MyForm";
            this.Text = "Trabalho 4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOrigImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEditedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem load2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox picOrigImage;
        private System.Windows.Forms.Label lblImageUnderTest;
        private System.Windows.Forms.PictureBox picEditedImage;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.Label inputImgDimensionsLabel;
        private System.Windows.Forms.Label outputImgDimensionsLabel;
        private System.Windows.Forms.ToolStripMenuItem smoothingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differentiateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xDirectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yDirectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonMaximumSupressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doubleThresholdingToolStripMenuItem;
    }
}

