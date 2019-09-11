using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourier_Transform {

    public class Peak {

        public double Amplitude, Frequency;

        public Peak(double amp, double freq) {
            Amplitude = amp;
            Frequency = freq;
            }
        }


    class FFT {
        const int power = 14;
        const int dataSize = 16384;

        public double[] rawData = new double[dataSize*5];
        public Complex[] X = new Complex[dataSize + 1];
        Complex U, W, TEMP;

        int l, j, k, m, LE, LE1;

        public int samplingRate;
        public double binSize;

        public FFT() {
            samplingRate = 16384;
            binSize = samplingRate / dataSize;
        }

        public int getDataSize() {
            return dataSize;
            }

        // Loading
        public void LoadSoundSample(string FileName) {
            string line;

                FileStream fs = new FileStream(FileName, FileMode.Open);
                StreamReader file = new StreamReader(fs);
                line = file.ReadLine(); //Skip the first line
                for (int i = 0; i < dataSize; i++) {
                    line = file.ReadLine();
                    X[i + 1] = new Complex(Convert.ToDouble(line));
                }
                file.Close();
                fs.Close();
            }
        public void LoadFifths() {
            samplingRate = rawData.Length / 5;
            binSize = Convert.ToDouble(samplingRate) / dataSize;
            binSize = Math.Round(binSize, 2);
            for (int i = 0; i < X.Length-1; i++) {
                X[i + 1] = new Complex(rawData[i * 5]);
            }
        }

        public void LoadFourths() {
            samplingRate = rawData.Length / 4;
            binSize = Convert.ToDouble(samplingRate) / dataSize;
            binSize = Math.Round(binSize, 2);
            for (int i = 0; i < X.Length - 1; i++) {
                X[i + 1] = new Complex(rawData[i * 4]);
            }
        }

        public void LoadThirds() {
            samplingRate = rawData.Length / 3;
            binSize = Convert.ToDouble(samplingRate) / dataSize;
            binSize = Math.Round(binSize, 2);
            for (int i = 0; i < X.Length - 1; i++) {
                X[i + 1] = new Complex(rawData[i * 3]);
            }
        }

        public void LoadRawData(string FileName) {
            string line;

            FileStream fs = new FileStream(FileName, FileMode.Open);
            StreamReader file = new StreamReader(fs);
            line = file.ReadLine(); //Skip the first line
            for (int i = 0; i < dataSize * 5; i++) {
                line = file.ReadLine();
                rawData[i] = Convert.ToDouble(line);
            }
            file.Close();
            fs.Close();
        }

        /*
         * Windowing
         */

        public void windowDataCircle() {
            //multiply data by sqrt((dataSize/2)^2 - (index - (dataSize/2))^2)
            double halfDS = dataSize / 2;
            for (int i = 0; i < dataSize; i++) {
                X[i + 1] *= Math.Sqrt( halfDS * halfDS - (i-halfDS)*(i - halfDS) );
            }
        }

        public void windowDataHanning() {
            //multiply data by sin^2(pi*index/dataSize)
            for (int i = 0; i < dataSize; i++) {
                X[i + 1] *= Math.Sin((Math.PI * i) / dataSize) * Math.Sin((Math.PI * i) / dataSize);
            }
        }

        public void windowDataHamming() {
            //multiply data by sin^2(pi*index/dataSize)
            for (int i = 0; i < dataSize; i++) {
                X[i + 1] *= 0.54 - 0.46*Math.Cos(2*Math.PI*i/dataSize);
            }
        }

        public void windowDataBlackmanHarris() {
            //multiply data by w(n) = a0 – a1cos(2pn/N) + a2cos(4pn/N) – a3cos(6pn/N).
            //a 0 = 0.355768, a1 = 0.487396, a2 = 0.144232, and a3 = 0.012604
            double a0 = 0.355768;
            double a1 = 0.487396;
            double a2 = 0.144232;
            double a3 = 0.012604;
            for (int i = 0; i < dataSize; i++) {
                X[i + 1] *= a0 - a1*Math.Cos(2*Math.PI*i/dataSize) + a2 * Math.Cos(4 * Math.PI * i / dataSize) - a3 * Math.Cos(6 * Math.PI * i / dataSize);
            }
        }

        /*
         * Filters
         */
         public void strictHighPass(double min) {
            for(int i = 1; i < X.Length-1; i++) {
                if(i*binSize < min) {
                    X[i] = new Complex(0);
                }
            }
         }

        public void strictLowPass(double max) {
            for (int i = 1; i < X.Length - 1; i++) {
                if (i * binSize > max) {
                    X[i] = new Complex(0);
                }
            }
        }

        public void filterRange(double min, double max) {
            for (int i = Convert.ToInt32(min/binSize); i < Convert.ToInt32(max); i++) {
                X[i] = new Complex(0);
            }
        }
       

        public List<Peak> getFrequencies() {
            //Loop through the data and find the indicies of peaks
            List<Peak> peaks = new List<Peak>();
            bool goingUp = false;
            //A peak occurs when the slope changes (goes up then down)
            for (int i = 1; i < dataSize/2; i++) {
                bool greaterThanLast = X[i+1].Magnitude() > X[i].Magnitude();

                if (greaterThanLast && goingUp == false)
                    goingUp = true;

                if (greaterThanLast == false && X[i].Magnitude() > 0.005 && goingUp == true) { //The previous index was a peak
                    
                    double freqMax = (i-1)*binSize;
                    double maxAmplitude = X[i].Magnitude();

                    peaks.Add(new Peak(maxAmplitude, freqMax));                   
                    
                    goingUp = false;
                    }
                }
            return peaks;
            }
        public List<Peak> getFrequencies(double minAmp) {
            //Loop through the data and find the indicies of peaks
            List<Peak> peaks = new List<Peak>();
            bool goingUp = false;
            //A peak occurs when the slope changes (goes up then down)
            for (int i = 1; i < dataSize / 2; i++) {
                bool greaterThanLast = X[i + 1].Magnitude() > X[i].Magnitude();

                if (greaterThanLast && goingUp == false)
                    goingUp = true;

                if (greaterThanLast == false && X[i].Magnitude() > minAmp && goingUp == true) { //The previous index was a peak

                    double freqMax = (i - 1) * binSize;
                    double maxAmplitude = X[i].Magnitude();

                    peaks.Add(new Peak(maxAmplitude, freqMax));

                    goingUp = false;
                }
            }
            return peaks;
        }


        /*
         * FFTs
         */

        public void fft() {
                //Re-Order/Invert the data for in-place calculation
                j = 1;
                for (int i = 1; i < dataSize; i++) {
                    if (i < j) { //Swap X[i] and X[j]
                        TEMP = X[j];
                        X[j] = X[i];
                        X[i] = TEMP;
                        }
                    k = dataSize / 2;
                    while (k < j) {
                        j -= k;
                        k /= 2;
                        }
                    j += k;
                    }

                //Compute the FFT in place
                for (k = 1; k <= power; k++) {
                    LE = (int)Math.Pow(2, k);
                    LE1 = LE / 2;
                    U = new Complex(1, 0);
                    W = new Complex(Math.Cos(Math.PI / LE1), -Math.Sin(Math.PI / LE1));
                    for (j = 1; j <= LE1; j++) {
                        for (int i = j; i <= dataSize; i += LE) {
                            m = i + LE1;
                            TEMP = X[m] * U;
                            X[m] = X[i] - TEMP;
                            X[i] += TEMP;
                            }
                        U *= W;
                        }
                    }

                //Scale the result
                for (k = 1; k <= dataSize; k++) {
                    X[k] /= dataSize;
                    }

                }

        public void ifft() {
            //Re-Order/Invert the data for in-place calculation
            j = 1;
            for (int i = 1; i < dataSize; i++) {
                if (i < j) { //Swap X[i] and X[j]
                    TEMP = X[j];
                    X[j] = X[i];
                    X[i] = TEMP;
                }
                k = dataSize / 2;
                while (k < j) {
                    j -= k;
                    k /= 2;
                }
                j += k;
            }

            //Compute the FFT in place
            for (k = 1; k <= power; k++) {
                LE = (int)Math.Pow(2, k);
                LE1 = LE / 2;
                U = new Complex(1, 0);
                W = new Complex(Math.Cos(Math.PI / LE1), Math.Sin(Math.PI / LE1));
                for (j = 1; j <= LE1; j++) {
                    for (int i = j; i <= dataSize; i += LE) {
                        m = i + LE1;
                        TEMP = X[m] * U;
                        X[m] = X[i] - TEMP;
                        X[i] += TEMP;
                    }
                    U *= W;
                }
            }

        }


        public
        class Complex {
            
            private double real, imag;

            public Complex(double rl, double im) {
                real = rl;
                imag = im;
                }
            public Complex(double rl) {
                real = rl;
                imag = 0;
                }

            public double Real{
                get { return (real); }
                set { real = value;  }
                }
            public double Imaginary {
                get { return (imag); }
                set { imag = value; }
                }

            public double Magnitude() {
                return Math.Sqrt(real * real + imag * imag);
                }
             public override string ToString() {
                return (String.Format("({0} + {1}i)", real, imag));
                }

            public static Complex operator+ (Complex c1, Complex c2) {
                return (new Complex(c1.Real+c2.Real, c1.Imaginary + c2.Imaginary));
                }

            public static Complex operator- (Complex c1, Complex c2) {
                return (new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary));
                }

            public static Complex operator* (Complex c1, Complex c2) {
                return (new Complex(
                    (c1.Real*c2.Real) - (c1.Imaginary*c2.Imaginary), 
                    (c1.Real*c2.Imaginary) + (c1.Imaginary*c2.Real)
                    ));
                }

            public static Complex operator* (Complex c1, double s) {
                return (new Complex(
                    (c1.Real * s),(c1.Imaginary * s)));
                }

            public static Complex operator/ (Complex c1, double s) {
                return (new Complex(
                    (c1.Real / s), (c1.Imaginary / s)));
                }

            public static bool operator== (Complex c1, Complex c2) {
                return ((c1.Real == c2.Real) && (c1.Imaginary == c2.Imaginary));
                }
            public static bool operator!= (Complex c1, Complex c2) {
                return ((c1.Real != c2.Real) || (c1.Real != c2.Imaginary));
                }

            }
        }
    }
