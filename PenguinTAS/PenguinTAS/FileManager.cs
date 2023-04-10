using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace PenguinTAS {
    public static class FileManager {
        public static RichTextBox? textBox1;
        public static RichTextBox? textBox2;

        static string? currentPath = null;

        public static void New() {
            textBox1!.Text = "#Player 1";
            textBox2!.Text = "#Player 2";
            SyntaxHighlighter.Highlight(textBox1, textBox2);
            currentPath = null;
        }

        public static void OpenPath(string path) {
            string[] text = File.ReadAllText(path).Split('|');
            textBox1!.Text = text[0];
            textBox2!.Text = text[1];
            SyntaxHighlighter.Highlight(textBox1, textBox2);
            currentPath = path;
        }

        public static void Open() {
            OpenFileDialog ofd = new();
            ofd.Filter = "TAS Files (.2tas)|*.2tas";
            ofd.Title = "Open...";
            if (ofd.ShowDialog() == DialogResult.OK) {
                string[] text = File.ReadAllText(ofd.FileName).Split('|');
                textBox1!.Text = text[0];
                textBox2!.Text = text[1];
                SyntaxHighlighter.Highlight(textBox1, textBox2);
                currentPath = ofd.FileName;
            }
        }

        public static void Save() {
            if (currentPath == null) {
                SaveAs();
                return;
            }

            File.WriteAllText(currentPath, textBox1!.Text + '|' + textBox2!.Text);
        }

        public static void SaveAs() {
            SaveFileDialog sfd = new();
            sfd.Filter = "TAS Files (.2tas)|*.2tas";
            sfd.Title = "Save...";
            if (sfd.ShowDialog() == DialogResult.OK) {
                File.WriteAllText(sfd.FileName, textBox1!.Text + '|' + textBox2!.Text);
                currentPath = sfd.FileName;
            }
        }
    }
}
