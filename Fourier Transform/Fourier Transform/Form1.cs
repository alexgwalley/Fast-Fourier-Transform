using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using NAudio.Wave;
using System.Windows.Forms.DataVisualization.Charting;

namespace Fourier_Transform {


    public partial class Form1 : Form {
        private FFT fft;

        WaveIn wi;
        WaveFileWriter wfw;

        private Dictionary<string, double> fundamentals;
        private Dictionary<int, string> noteNames;

        List<Peak> peaks;

        public Form1() {
            InitializeComponent();
            fft = new FFT();

            this.txtMinAmp.KeyDown += new KeyEventHandler(txtMinAmp_KeyDown);

            chrtOutput.MouseMove += chart_MouseMove;
            chrtPeaks.MouseMove += chart_MouseMove;

            chrtOutput.MouseClick += chrtOutput_MouseClick;
            chrtOutput.MouseWheel += chart_MouseWheel;
            chrtPeaks.MouseWheel += chart_MouseWheel;

            cmbWindowing.SelectedIndex = 3;

            noteNames = new Dictionary<int, string>();
            noteNames.Add(0, "A");
            noteNames.Add(1, "A#");
            noteNames.Add(2, "B");
            noteNames.Add(3, "C");
            noteNames.Add(4, "C#");
            noteNames.Add(5, "D");
            noteNames.Add(6, "D#");
            noteNames.Add(7, "E");
            noteNames.Add(8, "F");
            noteNames.Add(9, "F#");
            noteNames.Add(10, "G");
            noteNames.Add(11, "G#");

            fundamentals = new Dictionary<string, double>();
            calculateFundamentals();
        }

        ToolStripDropDown menu;
        private void Form1_Load(object sender, EventArgs e) {
            chrtOutput.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chrtOutput.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chrtOutput.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chrtOutput.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chrtOutput.ChartAreas[0].CursorX.AutoScroll = true;
            chrtOutput.ChartAreas[0].CursorY.AutoScroll = true;

            chrtPeaks.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chrtPeaks.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chrtPeaks.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chrtPeaks.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chrtPeaks.ChartAreas[0].CursorX.AutoScroll = true;
            chrtPeaks.ChartAreas[0].CursorY.AutoScroll = true;


            // Create Menu
            menu = new ToolStripDropDown();
            peaks = new List<Peak>();


            try { fft.LoadSoundSample("../../../FFT sound samples/440Hz.txt"); }
            catch (Exception ex) { txtOutput.AppendText("Could not load staring file"); }
        }

        /*
         * Mouse Stuff
         */

        private void chart_MouseMove(object sender, MouseEventArgs e) {
            var chart = (Chart)sender;


            try {
                double mouseX = Math.Round(chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X), 1);
                double mouseY = Math.Round(chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Y), 5);

                string cf = getClosestFundamental(mouseX);
                chart.Titles[1].Text = String.Format("Mouse Position: ( {0} , {1} ) Closest Fundamental: {2}", mouseX, mouseY, cf);

            }
            catch { }

        }

        private void chrtOutput_MouseClick(object sender, MouseEventArgs e) {
            chrtPeaks.Series[0].Points.Clear();

            double minPeakAmp;
            peaks.Clear();

            if (Double.TryParse(Convert.ToString(chrtOutput.ChartAreas[0].AxisY.PixelPositionToValue(e.Y)), out minPeakAmp) == true)
                peaks = fft.getFrequencies(minPeakAmp);
            else
                txtOutput.AppendText("\r\n Trouble reading minimum peak value, try again");

            chrtPeaks.Titles[0].Text = "Peaks";

            foreach (Peak p in peaks)
                chrtPeaks.Series[0].Points.AddXY(p.Frequency, p.Amplitude);
        }

        private void chart_MouseWheel(object sender, MouseEventArgs e) {
            Chart chart = (Chart)sender;
            if (e.Delta < 0) {
                chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            }
        }

        /*
         * Method that runs the fft of the .txt file in the FileName textBox
         */

        private void BtnGo_Click(object sender, EventArgs e) {
            try {
                fft.LoadFifths();
                fft.fft();
                chrtOutput.Titles["topGraph"].Text = "FFT";

                chrtOutput.Series[0]["PointWidth"] = "0.95";
                chrtPeaks.Series[0]["PointWidth"] = "0.8";

                chrtOutput.Series[0].Points.Clear();
                chrtPeaks.Series[0].Points.Clear();
                chrtOutput.Series[0].Points.AddXY(fft.binSize / 2, (fft.X[1].Magnitude()).ToString());


                for (int i = 1; i < fft.getDataSize()/2; i++) //Display half of data due to mirroring (Nyquist frequency)
                    chrtOutput.Series[0].Points.AddXY(i * fft.binSize + fft.binSize / 2, (fft.X[i].Magnitude()).ToString());
            }

            catch (Exception ex) {
                txtOutput.AppendText("\r\n" + ex.Message);
            }

            //Peaks
            chrtPeaks.Titles[0].Text = "Peaks";

            double minPeakAmp = 0.005;
            peaks.Clear();
            try {
                if (Double.TryParse(txtMinAmp.Text, out minPeakAmp) == true)
                    peaks = fft.getFrequencies(minPeakAmp);
                else
                    peaks = fft.getFrequencies();

                foreach (Peak p in peaks)
                    chrtPeaks.Series[0].Points.AddXY(p.Frequency, p.Amplitude);

            }
            catch (Exception ex) {
                txtOutput.AppendText("\r\n" + ex.Message);
            }

        }

        private void btnInvert_Click(object sender, EventArgs e) {
            fft.ifft();
            displayFFT();
        }

        //Windowing
        private void btnWindow_Click(object sender, EventArgs e) {

            if (cmbWindowing.SelectedIndex == 0)
                fft.windowDataCircle();
            else if (cmbWindowing.SelectedIndex == 1)
                fft.windowDataHanning();
            else if (cmbWindowing.SelectedIndex == 2)
                fft.windowDataHamming();
            else if (cmbWindowing.SelectedIndex == 3)
                fft.windowDataBlackmanHarris();

            displayFFT();
        }

        private void BtnPeaks_Click(object sender, EventArgs e) {
            for (int i = 0; i < chrtPeaks.Series[0].Points.Count; i++) {
                double freq = chrtPeaks.Series[0].Points[i].XValue;
                txtOutput.AppendText("Peak Frequency: " + freq + ", Closest Fundamental: " + getClosestFundamental(freq) + "\r\n");
            }
        }

        private void BtnClear_Click(object sender, EventArgs e) {
            txtOutput.Clear();
        }

        /*
         * Sets up an open file dialog for the user to select which audio file they would like to use
         */

        private void button1_Click(object sender, EventArgs e) {
            chrtOutput.Titles[0].Text = "File Wave Preview";

            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "Text Files (*.txt)|*.txt";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtFileName.Text = ofd.FileName;
                    try {
                        fft.LoadSoundSample(ofd.FileName);
                        displayFFT();
                    }
                    catch (Exception ex) {
                        txtOutput.AppendText("\r\nMethod:" + ex.TargetSite + " Message: " + ex.Message);
                    }
                }
            }
        }

        /*
         * Method that fills the top chart (chrtOutput) with the raw amplitudes from a .txt file
         */

        private void displayFile(string fileName) {

            chrtOutput.Series[0].Points.Clear();
            chrtOutput.Series[0].ChartType = SeriesChartType.Line;

            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
            System.IO.StreamReader file = new System.IO.StreamReader(fs);

            string line;
            line = file.ReadLine();

            int index = 1;
            while ((line = file.ReadLine()) != null) {
                double value;
                if (index++ % 25 == 0 && Double.TryParse(line, out value))
                    chrtOutput.Series[0].Points.AddXY(index * (1.0 / fft.samplingRate), value);
            }

            file.Close();
            fs.Close();

        }

        private void displayFFT(bool line = false) {
            chrtOutput.Series[0].Points.Clear();
            chrtOutput.Series[0].ChartType = SeriesChartType.Column;

            if (line)
                chrtOutput.Series[0].ChartType = SeriesChartType.Line;


            for (int i = 0; i < fft.X.Length - 1; i++)
                if (i % 2 == 0) chrtOutput.Series[0].Points.AddXY(i, fft.X[i + 1].Real);
        }

        private void displayFFTFrequencies() {
            chrtOutput.Series[0].Points.Clear();
            chrtOutput.Series[0].ChartType = SeriesChartType.Column;

            for (int i = 0; i < fft.X.Length / 2; i++)
                chrtOutput.Series[0].Points.AddXY(i * fft.binSize + fft.binSize / 2, fft.X[i + 1].Magnitude().ToString());
        }

        /*
         * Function that fills the peak chart with peaks from the fft using the fft.getFrequencies() method 
         */

        private void btnGetPeaks_Click_1(object sender, EventArgs e) {
            chrtPeaks.Series[0].Points.Clear();

            double minPeakAmp;
            peaks.Clear();

            if (Double.TryParse(txtMinAmp.Text, out minPeakAmp) == true)
                peaks = fft.getFrequencies(minPeakAmp);
            else
                txtOutput.AppendText("\r\n Trouble reading minimum peak value, try again");

            chrtPeaks.Titles[0].Text = "Peaks";

            foreach (Peak p in peaks)
                chrtPeaks.Series[0].Points.AddXY(p.Frequency, p.Amplitude);

        }

        private void txtMinAmp_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnGetPeaks_Click_1(sender, e);
                e.Handled = true;
            }
        }

        /*
         * Using the NuGet package NAudio, it records one second of audio with a sampling rate based on the fft
         * It outputs the file into temp.wav for later use
         */
        private void btnRecord_Click(object sender, EventArgs e) {

            int bytesRecorded = 0;

            btnRecord.Enabled = false;

            wi = new WaveIn();
            wi.WaveFormat = new WaveFormat(fft.samplingRate*5, 1);

            wi.RecordingStopped += new EventHandler<StoppedEventArgs>(wi_RecordingStopped);

            wi.DataAvailable += (s, a) => {
                if (wfw != null) {
                    bytesRecorded += a.BytesRecorded;
                    wfw.Write(a.Buffer, 0, a.BytesRecorded);
                    wfw.Flush();
                }
                if (bytesRecorded > fft.getDataSize() * 4) {
                    wi.StopRecording();
                }
            };

            wfw = new WaveFileWriter("temp.wav", wi.WaveFormat);
            try {
                wi.StartRecording();
                txtOutput.AppendText("Recording Started\r\n");

            }
            catch (Exception ex) {
                txtOutput.AppendText("\r\n" + ex.Message);
            }
        }
        void wi_RecordingStopped(object sender, StoppedEventArgs e) {
            txtOutput.AppendText("Recording Stopped\r\n");
            btnRecord.Enabled = true;
            if (wfw != null) {
                wfw.Dispose();
                wfw = null;
            }

            if (wi != null) {
                wi.Dispose();
                wi = null;
            }

            convertWaveToText("temp.wav");
            fft.LoadRawData("temp.txt");
        }
        /*
         * Converts a .wav file into a text file of amplitudes from -1.0 to 1.0
         * The .wav file contains a stereo input with Int16 precision of audio recording
         * */
        private void convertWaveToText(string fileName) {

            StreamWriter txtFile = new StreamWriter("temp.txt");
            txtFile.WriteLine("[Sampling Rate: " + fft.samplingRate + "Hz]");

            using (FileStream wavFileStream = File.OpenRead(fileName)) {

                byte[] buffer = new byte[1024];
                wavFileStream.Read(buffer, 0, 44);//Skip to the data sectionof the file
                while (wavFileStream.Read(buffer, 0, buffer.Length) > 0) {

                    for (int i = 0; i < buffer.Length; i += 2) {
                        Int16 number = BitConverter.ToInt16(buffer, i);

                        byte[] bigEndianArray = { (byte)((number << 8) & 0xff00), (byte)((number >> 8) & 0x00ff) };//Convert number to bigEndian

                        Int16 bigEndianNum = BitConverter.ToInt16(bigEndianArray, 0);

                        double realNumber = Convert.ToDouble(bigEndianNum);
                        realNumber /= (32767);

                        txtFile.WriteLine(Convert.ToString(realNumber));
                    }

                }
                wavFileStream.Close();
            }

            txtFile.Close();

            txtFileName.Text = "temp.txt";
            displayFile("temp.txt");
        }

        private void btnConvert_Click(object sender, EventArgs e) {
            convertWaveToText("temp.wav");
        }


        /*
         * Finding the note names
         * Calculate the fundamental frequencies
         */
        void calculateFundamentals() {
            //f(n) = f0 * (a)^n where n is the number of half steps from A4
            double a = 1.059463094359;
            for (int i = -57; i < 51; i++) {
                double frequency = 440 * Math.Pow(a, i);
                string letter;
                //Not sure why but the modulo will not work with negatives well, converted to positive by adding a multiple of 12
                noteNames.TryGetValue((i + 60) % 12, out letter);
                string octaveNumber = Convert.ToString(Math.Floor((double)(i + 57) / 12));

                fundamentals.Add(String.Format("{0}{1}", letter, octaveNumber), frequency);
            }
        }

        string getClosestFundamental(double freq) {

            double record = 10000;
            string key = "";

            foreach (var f in fundamentals) {
                double diff = Math.Abs(freq - f.Value);
                if (diff < record) {
                    key = f.Key;
                    record = diff;
                }
            }

            return key;
        }



        private void WaveFileToolStripMenuItem_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "Wave Files (*.wav)|*.wav|Text Files (*.txt)|*.txt";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    try {
                        convertWaveToText(ofd.FileName);

                        displayFile("temp.txt");
                        try {
                            fft.LoadRawData("temp.txt");
                        }
                        catch {
                            MessageBox.Show("Error loading text file. Check sampling rate. Must be " + fft.samplingRate * 5, "Error loading File");
                        }
                    }
                    catch (Exception ex) {
                        txtOutput.AppendText(ex.Message);
                    }
                }
            }
        }

        private void TextFileToolStripMenuItem_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "Text File (*.txt) | *.txt";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    try {
                        File.Copy(ofd.FileName, "temp.txt", true);
                        displayFile(ofd.FileName);
                        try {
                            fft.LoadRawData(ofd.FileName);
                        }catch {
                            MessageBox.Show("Error loading text file. Check sampling rate. Must be " + fft.samplingRate * 5, "Error loading File");
                        }
                    }
                    catch (Exception ex) {
                        txtOutput.AppendText(ex.Message);
                    }
                }
            }
        }

        /*
         * Saving
         */

        private void SaveAsWaveToolStripMenuItem_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.RestoreDirectory = true;
                sfd.Filter = "Wave Files (*.wav) | *.wav";
                if (sfd.ShowDialog() == DialogResult.OK) {
                    try {
                        File.Copy("temp.wav", sfd.FileName, true);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }

        private void SaveAsTextToolStripMenuItem_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.RestoreDirectory = true;
                sfd.Filter = "Text Files (*.txt) | *.txt";
                if (sfd.ShowDialog() == DialogResult.OK) {
                    try {
                        File.Copy("temp.txt", sfd.FileName, true);
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Error Saving File");
                    }
                }
            }
        }

        private void SaveAllFrequenciesToolStripMenuItem_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.RestoreDirectory = true;
                sfd.Filter = "Text file (*.txt) | *.txt";
                if (sfd.ShowDialog() == DialogResult.OK) {
                    try {
                        StreamWriter fileWriter = new StreamWriter(sfd.FileName);
                        fileWriter.AutoFlush = true;
                        for (int i = 1; i < fft.X.Length / 2; i++) {
                            fileWriter.WriteLine(i + "," + fft.X[i].Real + "," + fft.X[i].Imaginary);
                        }
                        fileWriter.Close();

                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Error saving file");
                    }
                }
            }
        }

       
        

       

        private void LoadFrequenciesToolStripMenuItem_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "Text Files (*.txt) | *.txt";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    try {
                        //Clear the current FFT
                        for (int i = 1; i < fft.X.Length; i++) {
                            fft.X[i] = new FFT.Complex(0);
                        }
                        using (StreamReader fileReader = new StreamReader(ofd.FileName)) {
                            string line, real, imag;
                            while ((line = fileReader.ReadLine()) != null) {
                                int index = Convert.ToInt32(line.Split(',')[0]);
                                real = line.Split(',')[1];
                                imag = line.Split(',')[2];
                                fft.X[index] = new FFT.Complex(Convert.ToDouble(real), Convert.ToDouble(imag));
                            }
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "Error Loading Frequencies");
                    }
                }
            }
            displayFFTFrequencies();
        }

        /*
         * Filters
         */

        private void strictHighPassToolStripMenuItem_Click(object sender, EventArgs e) {
            string answer;
            answer = PromptDialog.ShowDialog("Minimum Frequency to allow", "Strict High Pass Filter");
            try {
                double min = Convert.ToDouble(answer);
                fft.strictHighPass(min);
                displayFFTFrequencies();
            }catch (Exception ex) {
                MessageBox.Show("Unable to convert number to double", "Error parsing input");
            }
        }

        private void strictLowPassFilterToolStripMenuItem_Click(object sender, EventArgs e) {
            string answer;
            answer = PromptDialog.ShowDialog("Max Frequency to allow", "Strict High Pass Filter");
            try {
                double max = Convert.ToDouble(answer);
                fft.strictLowPass(max);
                displayFFTFrequencies();
                
            }
            catch (Exception ex) {
                MessageBox.Show("Unable to convert number to double", "Error parsing input");
            }
        }

        private void strictRangeFilterToolStripMenuItem_Click(object sender, EventArgs e) {
            string[] answers;
            if((answers = PromptDialog.ShowDialog("Minimum Frequency to allow", "Strict High Pass Filter", true)) != null) {
                try {
                    double min = Convert.ToDouble(answers[0]);
                    double max = Convert.ToDouble(answers[1]);
                    if(min > max) {
                        MessageBox.Show("Minimum must be less than Maximum", "Min Max Error");
                    }
                    else {
                        fft.filterRange(min, max);
                        displayFFTFrequencies();

                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error parsing input");
                }
            }else {
                MessageBox.Show("Invalid Inputs", "Error");
            }
            
        }

        private void btnPlayFFT_Click(object sender, EventArgs e) {
            WaveFormat wf = new WaveFormat(fft.samplingRate,1);

            short[] data = new short[fft.getDataSize()];
            for(int i = 0; i < fft.getDataSize(); i++) {
                data[i] = Convert.ToInt16(fft.X[i+1].Real*10);
            }

            using (WaveFileWriter wfw = new WaveFileWriter("temp.wav", wf)) {
                wfw.WriteSamples(data, 0, data.Length);
            }

            WaveOut wo = new WaveOut();
            WaveFileReader wfr = new WaveFileReader("temp.wav");
            wo.Init(wfr);
            wo.Play();

            wo.PlaybackStopped += (a,b) => {
                wo.Stop();
                wo.Dispose();
                wfr.Dispose();
            };
        }
    }
}
