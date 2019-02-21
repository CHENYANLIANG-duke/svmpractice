namespace svmpractice
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTestDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainSVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testSVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVMPredictOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dATAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tansformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtdatapath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsize = new System.Windows.Forms.TextBox();
            this.lblTest = new System.Windows.Forms.Label();
            this.lblOouputLabel = new System.Windows.Forms.Label();
            this.lblAccuracy = new System.Windows.Forms.Label();
            this.videoPredictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sVMToolStripMenuItem,
            this.dATAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(530, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataToolStripMenuItem,
            this.loadTestDataToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadDataToolStripMenuItem.Text = "Load train data";
            this.loadDataToolStripMenuItem.Click += new System.EventHandler(this.loadDataToolStripMenuItem_Click);
            // 
            // loadTestDataToolStripMenuItem
            // 
            this.loadTestDataToolStripMenuItem.Name = "loadTestDataToolStripMenuItem";
            this.loadTestDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadTestDataToolStripMenuItem.Text = "Load test data";
            this.loadTestDataToolStripMenuItem.Click += new System.EventHandler(this.loadTestDataToolStripMenuItem_Click);
            // 
            // sVMToolStripMenuItem
            // 
            this.sVMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainSVMToolStripMenuItem,
            this.testSVMToolStripMenuItem,
            this.sVMPredictOneToolStripMenuItem,
            this.videoPredictToolStripMenuItem});
            this.sVMToolStripMenuItem.Name = "sVMToolStripMenuItem";
            this.sVMToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.sVMToolStripMenuItem.Text = "SVM";
            // 
            // trainSVMToolStripMenuItem
            // 
            this.trainSVMToolStripMenuItem.Name = "trainSVMToolStripMenuItem";
            this.trainSVMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.trainSVMToolStripMenuItem.Text = "Train SVM";
            this.trainSVMToolStripMenuItem.Click += new System.EventHandler(this.trainSVMToolStripMenuItem_Click);
            // 
            // testSVMToolStripMenuItem
            // 
            this.testSVMToolStripMenuItem.Name = "testSVMToolStripMenuItem";
            this.testSVMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testSVMToolStripMenuItem.Text = "Test SVM";
            this.testSVMToolStripMenuItem.Click += new System.EventHandler(this.testSVMToolStripMenuItem_Click);
            // 
            // sVMPredictOneToolStripMenuItem
            // 
            this.sVMPredictOneToolStripMenuItem.Name = "sVMPredictOneToolStripMenuItem";
            this.sVMPredictOneToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sVMPredictOneToolStripMenuItem.Text = "SVM Predict One";
            this.sVMPredictOneToolStripMenuItem.Click += new System.EventHandler(this.sVMPredictOneToolStripMenuItem_Click);
            // 
            // dATAToolStripMenuItem
            // 
            this.dATAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tansformToolStripMenuItem});
            this.dATAToolStripMenuItem.Name = "dATAToolStripMenuItem";
            this.dATAToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dATAToolStripMenuItem.Text = "DATA";
            // 
            // tansformToolStripMenuItem
            // 
            this.tansformToolStripMenuItem.Name = "tansformToolStripMenuItem";
            this.tansformToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.tansformToolStripMenuItem.Text = "Tansform";
            this.tansformToolStripMenuItem.Click += new System.EventHandler(this.tansformToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 81);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 263);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 61);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Show Image";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 289);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "label4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 348);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "上一張";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 348);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "下一張";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtdatapath
            // 
            this.txtdatapath.Enabled = false;
            this.txtdatapath.Location = new System.Drawing.Point(9, 34);
            this.txtdatapath.Name = "txtdatapath";
            this.txtdatapath.Size = new System.Drawing.Size(227, 22);
            this.txtdatapath.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F);
            this.label1.Location = new System.Drawing.Point(252, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Imagesize:";
            // 
            // txtsize
            // 
            this.txtsize.Location = new System.Drawing.Point(332, 37);
            this.txtsize.Name = "txtsize";
            this.txtsize.Size = new System.Drawing.Size(43, 22);
            this.txtsize.TabIndex = 11;
            this.txtsize.Text = "50";
            this.txtsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(358, 185);
            this.lblTest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(33, 12);
            this.lblTest.TabIndex = 3;
            this.lblTest.Text = "label1";
            // 
            // lblOouputLabel
            // 
            this.lblOouputLabel.AutoSize = true;
            this.lblOouputLabel.Location = new System.Drawing.Point(358, 221);
            this.lblOouputLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOouputLabel.Name = "lblOouputLabel";
            this.lblOouputLabel.Size = new System.Drawing.Size(78, 12);
            this.lblOouputLabel.TabIndex = 4;
            this.lblOouputLabel.Text = "lblOouputLabel";
            // 
            // lblAccuracy
            // 
            this.lblAccuracy.AutoSize = true;
            this.lblAccuracy.Location = new System.Drawing.Point(358, 257);
            this.lblAccuracy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAccuracy.Name = "lblAccuracy";
            this.lblAccuracy.Size = new System.Drawing.Size(33, 12);
            this.lblAccuracy.TabIndex = 5;
            this.lblAccuracy.Text = "label3";
            // 
            // videoPredictToolStripMenuItem
            // 
            this.videoPredictToolStripMenuItem.Name = "videoPredictToolStripMenuItem";
            this.videoPredictToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.videoPredictToolStripMenuItem.Text = "Video Predict";
            this.videoPredictToolStripMenuItem.Click += new System.EventHandler(this.videoPredictToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 387);
            this.Controls.Add(this.txtsize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdatapath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblAccuracy);
            this.Controls.Add(this.lblOouputLabel);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sVMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainSVMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testSVMToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem dATAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tansformToolStripMenuItem;
        private System.Windows.Forms.TextBox txtdatapath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsize;
        private System.Windows.Forms.ToolStripMenuItem sVMPredictOneToolStripMenuItem;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Label lblOouputLabel;
        private System.Windows.Forms.Label lblAccuracy;
        private System.Windows.Forms.ToolStripMenuItem loadTestDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoPredictToolStripMenuItem;
    }
}

