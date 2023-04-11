namespace PenguinTAS;

public partial class PenguinTAS : Form {
    public static RichTextBox[] TextBoxes { get; private set; } = Array.Empty<RichTextBox>();

    public PenguinTAS(string? path) {
        InitializeComponent();
        TextBoxes = new RichTextBox[] { richTextBox1, richTextBox2 };
        //FileManager.textBox1 = richTextBox1;
        //FileManager.textBox2 = richTextBox2;
        //TextEditor.textBox = richTextBox1;
        if (path != null) {
            FileManager.OpenPath(path);
        }
        else {
            FileManager.New();
        }
    }

    private void Menu_New(object sender, EventArgs e) {
        FileManager.New();
    }

    private void Menu_Open(object sender, EventArgs e) {
        FileManager.Open();
    }

    private void Menu_Save(object sender, EventArgs e) {
        FileManager.Save();
    }

    private void Menu_SaveAs(object sender, EventArgs e) {
        FileManager.SaveAs();
    }

    private void Menu_Exit(object sender, EventArgs e) {
        Application.Exit();
    }

    private void Menu_Undo(object sender, EventArgs e) {
        //richTextBox1.Undo();
    }

    private void Menu_Redo(object sender, EventArgs e) {
        //richTextBox1.Redo();
    }

    private void Menu_Cut(object sender, EventArgs e) {
        //richTextBox1.Cut();
    }

    private void Menu_Copy(object sender, EventArgs e) {
        //richTextBox1.Copy();
    }

    private void Menu_Paste(object sender, EventArgs e) {
        //richTextBox1.Paste();
    }

    private void Menu_SelectAll(object sender, EventArgs e) {
        richTextBox1.SelectAll();
        SyntaxHighlighter.Highlight(richTextBox1, richTextBox2);
    }

    private void TextBox_KeyPress(object sender, KeyPressEventArgs e) {
        RichTextBox textBox = (RichTextBox)sender;
        e.Handled = InputHandler.HandleCharInput(textBox, e);
    }

    private void TextBox_KeyDown(object sender, KeyEventArgs e) {
        RichTextBox textBox = (RichTextBox)sender;
        e.Handled = InputHandler.HandleKeyInput(textBox, e);
    }

    private void TextBox_TextChanged(object sender, EventArgs e) {
        RichTextBox textBox = (RichTextBox)sender;
    }

    private void TextBox_SelectionChanged(object sender, EventArgs e) {
        RichTextBox textBox = (RichTextBox)sender;
    }
}