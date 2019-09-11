namespace Fourier_Transform
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 2D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 2D);
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.chrtOutput = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chrtPeaks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnPeaks = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWindowing = new System.Windows.Forms.ComboBox();
            this.txtMinAmp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetPeaks = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnWindow = new System.Windows.Forms.Button();
            this.menuFileItem = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFrequenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsWaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllFrequenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strictHighPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strictLowPassFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strictRangeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInvert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chrtOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPeaks)).BeginInit();
            this.menuFileItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(1060, 12);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(453, 348);
            this.txtOutput.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(1060, 628);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(238, 50);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // chrtOutput
            // 
            chartArea1.AxisX.Title = "Frequency (Hz)";
            chartArea1.AxisY.Title = "Amplitude ";
            chartArea1.Name = "ChartArea1";
            this.chrtOutput.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtOutput.Legends.Add(legend1);
            this.chrtOutput.Location = new System.Drawing.Point(0, 27);
            this.chrtOutput.Name = "chrtOutput";
            this.chrtOutput.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chrtOutput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            this.chrtOutput.Series.Add(series1);
            this.chrtOutput.Size = new System.Drawing.Size(1054, 368);
            this.chrtOutput.TabIndex = 3;
            this.chrtOutput.Text = "            ";
            title1.Name = "topGraph";
            title1.Text = "Name";
            title2.Name = "mousePos";
            title2.Text = "Mouse Position:";
            this.chrtOutput.Titles.Add(title1);
            this.chrtOutput.Titles.Add(title2);
            // 
            // chrtPeaks
            // 
            chartArea2.AxisX.Title = "Frequency (Hz)";
            chartArea2.AxisY.Title = "Amplitude ";
            chartArea2.Name = "ChartArea1";
            this.chrtPeaks.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrtPeaks.Legends.Add(legend2);
            this.chrtPeaks.Location = new System.Drawing.Point(0, 401);
            this.chrtPeaks.Name = "chrtPeaks";
            this.chrtPeaks.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chrtPeaks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.Points.Add(dataPoint3);
            series2.Points.Add(dataPoint4);
            this.chrtPeaks.Series.Add(series2);
            this.chrtPeaks.Size = new System.Drawing.Size(1054, 291);
            this.chrtPeaks.TabIndex = 4;
            this.chrtPeaks.Text = "            ";
            title3.Name = "Peaks";
            title3.Text = "Peaks";
            title4.Name = "mousePos";
            title4.Text = "Mouse Position:";
            this.chrtPeaks.Titles.Add(title3);
            this.chrtPeaks.Titles.Add(title4);
            // 
            // btnPeaks
            // 
            this.btnPeaks.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeaks.Location = new System.Drawing.Point(1304, 628);
            this.btnPeaks.Name = "btnPeaks";
            this.btnPeaks.Size = new System.Drawing.Size(209, 50);
            this.btnPeaks.TabIndex = 5;
            this.btnPeaks.Text = "Print Peaks";
            this.btnPeaks.UseVisualStyleBackColor = true;
            this.btnPeaks.Click += new System.EventHandler(this.BtnPeaks_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(1304, 572);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(209, 50);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear Text Box";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(1145, 367);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(368, 20);
            this.txtFileName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1060, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "File Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1057, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Windowing:";
            // 
            // cmbWindowing
            // 
            this.cmbWindowing.FormattingEnabled = true;
            this.cmbWindowing.Items.AddRange(new object[] {
            "Circle",
            "Hanning",
            "Hamming",
            "Blackman-Harris"});
            this.cmbWindowing.Location = new System.Drawing.Point(1063, 422);
            this.cmbWindowing.Name = "cmbWindowing";
            this.cmbWindowing.Size = new System.Drawing.Size(121, 21);
            this.cmbWindowing.TabIndex = 14;
            // 
            // txtMinAmp
            // 
            this.txtMinAmp.Location = new System.Drawing.Point(1308, 422);
            this.txtMinAmp.Name = "txtMinAmp";
            this.txtMinAmp.Size = new System.Drawing.Size(124, 20);
            this.txtMinAmp.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1246, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Min Peak Amplitude:\r\n";
            // 
            // btnGetPeaks
            // 
            this.btnGetPeaks.Location = new System.Drawing.Point(1438, 419);
            this.btnGetPeaks.Name = "btnGetPeaks";
            this.btnGetPeaks.Size = new System.Drawing.Size(75, 23);
            this.btnGetPeaks.TabIndex = 17;
            this.btnGetPeaks.Text = "Get Peaks";
            this.btnGetPeaks.UseVisualStyleBackColor = true;
            this.btnGetPeaks.Click += new System.EventHandler(this.btnGetPeaks_Click_1);
            // 
            // btnRecord
            // 
            this.btnRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord.Location = new System.Drawing.Point(1063, 449);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(235, 50);
            this.btnRecord.TabIndex = 18;
            this.btnRecord.Text = "Record Audio";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnWindow
            // 
            this.btnWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindow.Location = new System.Drawing.Point(1304, 451);
            this.btnWindow.Name = "btnWindow";
            this.btnWindow.Size = new System.Drawing.Size(209, 50);
            this.btnWindow.TabIndex = 19;
            this.btnWindow.Text = "Window";
            this.btnWindow.UseVisualStyleBackColor = true;
            this.btnWindow.Click += new System.EventHandler(this.btnWindow_Click);
            // 
            // menuFileItem
            // 
            this.menuFileItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuFileItem.Location = new System.Drawing.Point(0, 0);
            this.menuFileItem.Name = "menuFileItem";
            this.menuFileItem.Size = new System.Drawing.Size(1525, 24);
            this.menuFileItem.TabIndex = 21;
            this.menuFileItem.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWaveToolStripMenuItem,
            this.saveWaveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openWaveToolStripMenuItem
            // 
            this.openWaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.waveFileToolStripMenuItem,
            this.textFileToolStripMenuItem,
            this.loadFrequenciesToolStripMenuItem});
            this.openWaveToolStripMenuItem.Name = "openWaveToolStripMenuItem";
            this.openWaveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openWaveToolStripMenuItem.Text = "Open File";
            // 
            // waveFileToolStripMenuItem
            // 
            this.waveFileToolStripMenuItem.Name = "waveFileToolStripMenuItem";
            this.waveFileToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.waveFileToolStripMenuItem.Text = "Wave File";
            this.waveFileToolStripMenuItem.Click += new System.EventHandler(this.WaveFileToolStripMenuItem_Click);
            // 
            // textFileToolStripMenuItem
            // 
            this.textFileToolStripMenuItem.Name = "textFileToolStripMenuItem";
            this.textFileToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.textFileToolStripMenuItem.Text = "Text File";
            this.textFileToolStripMenuItem.Click += new System.EventHandler(this.TextFileToolStripMenuItem_Click);
            // 
            // loadFrequenciesToolStripMenuItem
            // 
            this.loadFrequenciesToolStripMenuItem.Name = "loadFrequenciesToolStripMenuItem";
            this.loadFrequenciesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.loadFrequenciesToolStripMenuItem.Text = "Load Frequencies";
            this.loadFrequenciesToolStripMenuItem.Click += new System.EventHandler(this.LoadFrequenciesToolStripMenuItem_Click);
            // 
            // saveWaveToolStripMenuItem
            // 
            this.saveWaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsWaveToolStripMenuItem,
            this.saveAsTextToolStripMenuItem,
            this.saveAllFrequenciesToolStripMenuItem});
            this.saveWaveToolStripMenuItem.Name = "saveWaveToolStripMenuItem";
            this.saveWaveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveWaveToolStripMenuItem.Text = "Save File";
            // 
            // saveAsWaveToolStripMenuItem
            // 
            this.saveAsWaveToolStripMenuItem.Name = "saveAsWaveToolStripMenuItem";
            this.saveAsWaveToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveAsWaveToolStripMenuItem.Text = "Save As Wave";
            this.saveAsWaveToolStripMenuItem.Click += new System.EventHandler(this.SaveAsWaveToolStripMenuItem_Click);
            // 
            // saveAsTextToolStripMenuItem
            // 
            this.saveAsTextToolStripMenuItem.Name = "saveAsTextToolStripMenuItem";
            this.saveAsTextToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveAsTextToolStripMenuItem.Text = "Save As Text";
            this.saveAsTextToolStripMenuItem.Click += new System.EventHandler(this.SaveAsTextToolStripMenuItem_Click);
            // 
            // saveAllFrequenciesToolStripMenuItem
            // 
            this.saveAllFrequenciesToolStripMenuItem.Name = "saveAllFrequenciesToolStripMenuItem";
            this.saveAllFrequenciesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveAllFrequenciesToolStripMenuItem.Text = "Save Frequencies";
            this.saveAllFrequenciesToolStripMenuItem.Click += new System.EventHandler(this.SaveAllFrequenciesToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strictHighPassToolStripMenuItem,
            this.strictLowPassFilterToolStripMenuItem,
            this.strictRangeFilterToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.editToolStripMenuItem.Text = "Filters";
            // 
            // strictHighPassToolStripMenuItem
            // 
            this.strictHighPassToolStripMenuItem.Name = "strictHighPassToolStripMenuItem";
            this.strictHighPassToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.strictHighPassToolStripMenuItem.Text = "Strict High Pass Filter";
            this.strictHighPassToolStripMenuItem.Click += new System.EventHandler(this.strictHighPassToolStripMenuItem_Click);
            // 
            // strictLowPassFilterToolStripMenuItem
            // 
            this.strictLowPassFilterToolStripMenuItem.Name = "strictLowPassFilterToolStripMenuItem";
            this.strictLowPassFilterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.strictLowPassFilterToolStripMenuItem.Text = "Strict Low Pass Filter";
            this.strictLowPassFilterToolStripMenuItem.Click += new System.EventHandler(this.strictLowPassFilterToolStripMenuItem_Click);
            // 
            // strictRangeFilterToolStripMenuItem
            // 
            this.strictRangeFilterToolStripMenuItem.Name = "strictRangeFilterToolStripMenuItem";
            this.strictRangeFilterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.strictRangeFilterToolStripMenuItem.Text = "Strict Range Filter";
            this.strictRangeFilterToolStripMenuItem.Click += new System.EventHandler(this.strictRangeFilterToolStripMenuItem_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvert.Location = new System.Drawing.Point(1060, 572);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(238, 50);
            this.btnInvert.TabIndex = 22;
            this.btnInvert.Text = "Invert";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1525, 704);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.btnWindow);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnGetPeaks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMinAmp);
            this.Controls.Add(this.cmbWindowing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPeaks);
            this.Controls.Add(this.chrtPeaks);
            this.Controls.Add(this.chrtOutput);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.menuFileItem);
            this.MainMenuStrip = this.menuFileItem;
            this.Name = "Form1";
            this.Text = "Fast Fourier Transform";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chrtOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPeaks)).EndInit();
            this.menuFileItem.ResumeLayout(false);
            this.menuFileItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtOutput;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtPeaks;
        private System.Windows.Forms.Button btnPeaks;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWindowing;
        private System.Windows.Forms.TextBox txtMinAmp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetPeaks;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnWindow;
        private System.Windows.Forms.MenuStrip menuFileItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFrequenciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsWaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsTextToolStripMenuItem;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.ToolStripMenuItem saveAllFrequenciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strictHighPassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strictLowPassFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strictRangeFilterToolStripMenuItem;
    }
}

