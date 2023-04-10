using System.Security.Cryptography;
using System.Windows.Forms;

namespace PenguinTAS {
    public static class FileManager {
        public static RichTextBox? textBox;

        static string? currentPath = null;

        public static void New() {
            textBox!.Clear();
            currentPath = null;
        }

        public static void OpenPath(string path) {
            textBox!.Text = File.ReadAllText(path);
            currentPath = path;
        }

        public static void Open() {
            OpenFileDialog ofd = new();
            ofd.Filter = "TAS Files (.2tas)|*.2tas";
            ofd.Title = "Open...";
            if (ofd.ShowDialog() == DialogResult.OK) {
                textBox!.Text = File.ReadAllText(ofd.FileName);
                currentPath = ofd.FileName;
            }
        }

        public static void Save() {
            if (currentPath == null) {
                SaveAs();
                return;
            }

            File.WriteAllText(currentPath, textBox!.Text);
        }

        public static void SaveAs() {
            SaveFileDialog sfd = new();
            sfd.Filter = "TAS Files (.2tas)|*.2tas";
            sfd.Title = "Save...";
            if (sfd.ShowDialog() == DialogResult.OK) {
                File.WriteAllText(sfd.FileName, textBox!.Text);
                currentPath = sfd.FileName;
            }
        }
    }
}
