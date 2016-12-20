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
            this.convertToGrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightenImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convolveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kernel1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kernel2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topSobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftSobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightSobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kernel3GaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramEqualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToGrayFirstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usingOriginalImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateFillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
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
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.loadToolStripMenuItem.Text = "File";
            // 
            // load2ToolStripMenuItem
            // 
            this.load2ToolStripMenuItem.Name = "load2ToolStripMenuItem";
            this.load2ToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.load2ToolStripMenuItem.Text = "Load Image";
            this.load2ToolStripMenuItem.Click += new System.EventHandler(this.load2ToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToGrayToolStripMenuItem,
            this.brightenImageToolStripMenuItem,
            this.contrastImageToolStripMenuItem,
            this.resizeImageToolStripMenuItem,
            this.convolveImageToolStripMenuItem,
            this.histogramEqualizationToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // convertToGrayToolStripMenuItem
            // 
            this.convertToGrayToolStripMenuItem.Name = "convertToGrayToolStripMenuItem";
            this.convertToGrayToolStripMenuItem.Size = new System.Drawing.Size(281, 30);
            this.convertToGrayToolStripMenuItem.Text = "Convert to Gray";
            this.convertToGrayToolStripMenuItem.Click += new System.EventHandler(this.convertToGrayToolStripMenuItem_Click);
            // 
            // brightenImageToolStripMenuItem
            // 
            this.brightenImageToolStripMenuItem.Name = "brightenImageToolStripMenuItem";
            this.brightenImageToolStripMenuItem.Size = new System.Drawing.Size(281, 30);
            this.brightenImageToolStripMenuItem.Text = "Brighten Image";
            this.brightenImageToolStripMenuItem.Click += new System.EventHandler(this.brightenImageToolStripMenuItem_Click);
            // 
            // contrastImageToolStripMenuItem
            // 
            this.contrastImageToolStripMenuItem.Name = "contrastImageToolStripMenuItem";
            this.contrastImageToolStripMenuItem.Size = new System.Drawing.Size(281, 30);
            this.contrastImageToolStripMenuItem.Text = "Contrast Image";
            this.contrastImageToolStripMenuItem.Click += new System.EventHandler(this.contrastImageToolStripMenuItem_Click);
            // 
            // resizeImageToolStripMenuItem
            // 
            this.resizeImageToolStripMenuItem.Name = "resizeImageToolStripMenuItem";
            this.resizeImageToolStripMenuItem.Size = new System.Drawing.Size(281, 30);
            this.resizeImageToolStripMenuItem.Text = "Resize Image";
            this.resizeImageToolStripMenuItem.Click += new System.EventHandler(this.resizeImageToolStripMenuItem_Click);
            // 
            // convolveImageToolStripMenuItem
            // 
            this.convolveImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kernel1ToolStripMenuItem,
            this.kernel2ToolStripMenuItem,
            this.kernel3GaussianToolStripMenuItem});
            this.convolveImageToolStripMenuItem.Name = "convolveImageToolStripMenuItem";
            this.convolveImageToolStripMenuItem.Size = new System.Drawing.Size(281, 30);
            this.convolveImageToolStripMenuItem.Text = "Convolve Image";
            // 
            // kernel1ToolStripMenuItem
            // 
            this.kernel1ToolStripMenuItem.Name = "kernel1ToolStripMenuItem";
            this.kernel1ToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.kernel1ToolStripMenuItem.Text = "Kernel 1";
            this.kernel1ToolStripMenuItem.Click += new System.EventHandler(this.kernel1ToolStripMenuItem_Click);
            // 
            // kernel2ToolStripMenuItem
            // 
            this.kernel2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topSobelToolStripMenuItem,
            this.leftSobelToolStripMenuItem,
            this.rightSobelToolStripMenuItem});
            this.kernel2ToolStripMenuItem.Name = "kernel2ToolStripMenuItem";
            this.kernel2ToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.kernel2ToolStripMenuItem.Text = "Kernel 2 (Sobel)";
            // 
            // topSobelToolStripMenuItem
            // 
            this.topSobelToolStripMenuItem.Name = "topSobelToolStripMenuItem";
            this.topSobelToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.topSobelToolStripMenuItem.Text = "Top Sobel";
            this.topSobelToolStripMenuItem.Click += new System.EventHandler(this.topSobelToolStripMenuItem_Click);
            // 
            // leftSobelToolStripMenuItem
            // 
            this.leftSobelToolStripMenuItem.Name = "leftSobelToolStripMenuItem";
            this.leftSobelToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.leftSobelToolStripMenuItem.Text = "Left Sobel";
            this.leftSobelToolStripMenuItem.Click += new System.EventHandler(this.leftSobelToolStripMenuItem_Click);
            // 
            // rightSobelToolStripMenuItem
            // 
            this.rightSobelToolStripMenuItem.Name = "rightSobelToolStripMenuItem";
            this.rightSobelToolStripMenuItem.Size = new System.Drawing.Size(189, 30);
            this.rightSobelToolStripMenuItem.Text = "Right Sobel";
            this.rightSobelToolStripMenuItem.Click += new System.EventHandler(this.rightSobelToolStripMenuItem_Click);
            // 
            // kernel3GaussianToolStripMenuItem
            // 
            this.kernel3GaussianToolStripMenuItem.Name = "kernel3GaussianToolStripMenuItem";
            this.kernel3GaussianToolStripMenuItem.Size = new System.Drawing.Size(245, 30);
            this.kernel3GaussianToolStripMenuItem.Text = "Kernel 3 (Gaussian)";
            this.kernel3GaussianToolStripMenuItem.Click += new System.EventHandler(this.kernel3GaussianToolStripMenuItem_Click);
            // 
            // histogramEqualizationToolStripMenuItem
            // 
            this.histogramEqualizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToGrayFirstToolStripMenuItem,
            this.usingOriginalImageToolStripMenuItem});
            this.histogramEqualizationToolStripMenuItem.Name = "histogramEqualizationToolStripMenuItem";
            this.histogramEqualizationToolStripMenuItem.Size = new System.Drawing.Size(281, 30);
            this.histogramEqualizationToolStripMenuItem.Text = "Histogram Equalization";
            // 
            // convertToGrayFirstToolStripMenuItem
            // 
            this.convertToGrayFirstToolStripMenuItem.Name = "convertToGrayFirstToolStripMenuItem";
            this.convertToGrayFirstToolStripMenuItem.Size = new System.Drawing.Size(264, 30);
            this.convertToGrayFirstToolStripMenuItem.Text = "Convert to Gray First";
            this.convertToGrayFirstToolStripMenuItem.Click += new System.EventHandler(this.convertToGrayFirstToolStripMenuItem_Click);
            // 
            // usingOriginalImageToolStripMenuItem
            // 
            this.usingOriginalImageToolStripMenuItem.Name = "usingOriginalImageToolStripMenuItem";
            this.usingOriginalImageToolStripMenuItem.Size = new System.Drawing.Size(264, 30);
            this.usingOriginalImageToolStripMenuItem.Text = "Using Original Image";
            this.usingOriginalImageToolStripMenuItem.Click += new System.EventHandler(this.usingOriginalImageToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shiftHorizontalToolStripMenuItem,
            this.shiftVerticalToolStripMenuItem,
            this.rotateClearToolStripMenuItem,
            this.rotateFillToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // shiftHorizontalToolStripMenuItem
            // 
            this.shiftHorizontalToolStripMenuItem.Name = "shiftHorizontalToolStripMenuItem";
            this.shiftHorizontalToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.shiftHorizontalToolStripMenuItem.Text = "Shift Horizontal";
            this.shiftHorizontalToolStripMenuItem.Click += new System.EventHandler(this.shiftHorizontalToolStripMenuItem_Click);
            // 
            // shiftVerticalToolStripMenuItem
            // 
            this.shiftVerticalToolStripMenuItem.Name = "shiftVerticalToolStripMenuItem";
            this.shiftVerticalToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.shiftVerticalToolStripMenuItem.Text = "Shift Vertical";
            this.shiftVerticalToolStripMenuItem.Click += new System.EventHandler(this.shiftVerticalToolStripMenuItem_Click);
            // 
            // rotateClearToolStripMenuItem
            // 
            this.rotateClearToolStripMenuItem.Name = "rotateClearToolStripMenuItem";
            this.rotateClearToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.rotateClearToolStripMenuItem.Text = "Rotate Clear";
            this.rotateClearToolStripMenuItem.Click += new System.EventHandler(this.rotateClearToolStripMenuItem_Click);
            // 
            // rotateFillToolStripMenuItem
            // 
            this.rotateFillToolStripMenuItem.Name = "rotateFillToolStripMenuItem";
            this.rotateFillToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.rotateFillToolStripMenuItem.Text = "Rotate Fill";
            this.rotateFillToolStripMenuItem.Click += new System.EventHandler(this.rotateFillToolStripMenuItem_Click);
            // 
            // picOrigImage
            // 
            this.picOrigImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOrigImage.Location = new System.Drawing.Point(12, 92);
            this.picOrigImage.Name = "picOrigImage";
            this.picOrigImage.Size = new System.Drawing.Size(847, 888);
            this.picOrigImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            this.picEditedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            this.ClientSize = new System.Drawing.Size(1902, 1038);
            this.Controls.Add(this.outputImgDimensionsLabel);
            this.Controls.Add(this.inputImgDimensionsLabel);
            this.Controls.Add(this.picEditedImage);
            this.Controls.Add(this.lblImageUnderTest);
            this.Controls.Add(this.picOrigImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MyForm";
            this.Text = "Assignment2";
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
        private System.Windows.Forms.ToolStripMenuItem convertToGrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightenImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateFillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeImageToolStripMenuItem;
        private System.Windows.Forms.Label inputImgDimensionsLabel;
        private System.Windows.Forms.Label outputImgDimensionsLabel;
        private System.Windows.Forms.ToolStripMenuItem convolveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kernel1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kernel2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kernel3GaussianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramEqualizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topSobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftSobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightSobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToGrayFirstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usingOriginalImageToolStripMenuItem;
    }
}

