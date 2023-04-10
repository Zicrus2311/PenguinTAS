namespace PenguinTAS {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            FileManager.New(richTextBox1);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            FileManager.Open(richTextBox1);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            FileManager.Save(richTextBox1);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            FileManager.SaveAs(richTextBox1);
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {

        }
    }
}