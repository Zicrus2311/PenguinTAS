using System.Security.Cryptography;
using System.Windows.Forms;

namespace PenguinTAS {
    public static class FileManager {
        static string? currentPath = null;

        public static void New(RichTextBox textBox) {
            textBox.Clear();
            currentPath = null;
        }

        public static void OpenPath(RichTextBox textBox, string path) {
            textBox.Text = File.ReadAllText(path);
            currentPath = path;
        }

        public static void Open(RichTextBox textBox) {
            OpenFileDialog ofd = new();
            ofd.Filter = "TAS Files (.2tas)|*.2tas";
            ofd.Title = "Open...";
            if (ofd.ShowDialog() == DialogResult.OK) {
                textBox.Text = File.ReadAllText(ofd.FileName);
                currentPath = ofd.FileName;
            }
        }

        public static void Save(RichTextBox textBox) {
            if (currentPath == null) {
                SaveAs(textBox);
                return;
            }

            File.WriteAllText(currentPath, textBox.Text);
        }

        public static void SaveAs(RichTextBox textBox) {
            SaveFileDialog sfd = new();
            sfd.Filter = "TAS Files (.2tas)|*.2tas";
            sfd.Title = "Save...";
            if (sfd.ShowDialog() == DialogResult.OK) {
                File.WriteAllText(sfd.FileName, textBox.Text);
                currentPath = sfd.FileName;
            }
        }
    }
}
