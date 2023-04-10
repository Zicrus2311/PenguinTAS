namespace PenguinTAS {
    public partial class Form1 : Form {
        public Form1(string? path) {
            InitializeComponent();
            if (path != null) {
                FileManager.OpenPath( path);
            }
            FileManager.textBox = richTextBox1;
            TextEditor.textBox = richTextBox1;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            FileManager.New();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            FileManager.Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            FileManager.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            FileManager.SaveAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e) {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) {
            richTextBox1.SelectAll();
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = TextEditor.HandleCharInput(e);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = TextEditor.HandleKeyInput(e);
        }
    }
}