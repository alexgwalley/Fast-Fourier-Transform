using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fourier_Transform {
    class PromptDialog {
        public static string ShowDialog(string text, string caption) {
            Form prompt = new Form() {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Enter", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            textBox.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) prompt.Close(); };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public static string[] ShowDialog(string text, string caption, bool twoPrompts) {
            Form prompt = new Form() {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox1 = new TextBox() { Left = 50, Top = 50, Width = 150 };
            TextBox textBox2 = new TextBox() { Left = 250, Top = 50, Width = 150 };
            Button confirmation = new Button() { Text = "Enter", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            textBox2.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) prompt.Close(); };
            textBox1.KeyDown += (sender, e) => { if (e.KeyCode == Keys.Enter) prompt.Close(); };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox1);
            prompt.Controls.Add(textBox2);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            

            return prompt.ShowDialog() == DialogResult.OK ? new string[2] { textBox1.Text, textBox2.Text } : null;
        }
    }
}

